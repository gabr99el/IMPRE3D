using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using apiUniversidade.DTO;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
//rever a identação 

[ApiController]
[Route ("[controller]")]
public class AutorizaController : Controller

{
    private readonly UserManager<IdentityUser> _userManager;

    private readonly SignInManager<IdentityUser> _signInManager; 

    private readonly IConfiguration _configuration;
    
    public AutorizaController(UserManager<IdentityUser> userManager, 
    SignInManager<IdentityUser> signInManager,IConfiguration configuration )
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;

    }

    [HttpGet]
    public ActionResult<string> Get (){
        return "AutorizaController :: Acessado em : "
            + DateTime.Now.ToLongDateString();
    }

    [HttpPost("register")]
    public async Task<ActionResult> RegisterUser ([FromBody] UsuarioDTO model) {
        var user = new IdentityUser{
            UserName= model.Email,
            Email = model.Email,
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync (user, model.Password);
        if (!result.Succeeded)
            return BadRequest (result.Errors);

        await _signInManager.SignInAsync (user, false);
        return Ok (Geratoken(model));
    }

    [HttpPost("login")]
        public async Task<ActionResult> Login ([FromBody] UsuarioDTO userInfo){
            var result = await _signInManager.PasswordSignInAsync(userInfo.Email, userInfo.Password, 
                    isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
                return Ok(Geratoken(userInfo));
            else {
                ModelState.AddModelError(string.Empty, "Login Inválido...");
                return BadRequest (ModelState);
            }
        }

    private UsuarioToken Geratoken (UsuarioDTO userInfo){

        var claims = new []{
            new Claim (System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.UniqueName,userInfo.Email),
            new Claim ("IFRN", "TecInfo"),
            new Claim (Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            //gerar chave através de um algoritimo de chave simétrica
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));

            //gerar a assinatura digital do token utilizado 
            //a cave privada (key) e o algoritimo HMAC SHA 256
             var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            
            //tempo de expiracao do token
             var expiracao = _configuration ["TokenConfiguration:ExpireHours"];
             var expiration = DateTime.UtcNow.AddHours(double.Parse(expiracao));

             JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["TokenConfiguration:Issuer"],
                audience: _configuration ["TokenConfiguration:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
             );

            return new UsuarioToken(){
                Authenticated = true,
                Expiration = expiration,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Message = "JWT ok"
            };
        }
}

