﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductionOrderSEQUOR.API.Models;
using ProductionOrderSEQUOR.Application.DTOs;
using ProductionOrderSEQUOR.Application.Interfaces;
using ProductionOrderSEQUOR.Domain.Account;

namespace ProductionOrderSEQUOR.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UsuarioController : Controller
    {
        private readonly IAuthenticate _authenticateService;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IAuthenticate authenticateService, IUsuarioService usuarioService)
        {
            _authenticateService = authenticateService;
            _usuarioService = usuarioService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserToken>> Incluir(UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
            {
                return BadRequest("Dados inválidos");

            }
            var emailExiste = await _authenticateService.UserExists(usuarioDTO.Email);
            if (emailExiste)
            {
                return BadRequest("Este e-mail já possui um cadastro!");
            }
            var usuario = await _usuarioService.Incluir(usuarioDTO);
            if (usuario == null)
            {
                return BadRequest("Ocorreu um erro ao cadastrar.");
            }
            var token = _authenticateService.GenerateToken(usuario.Id, usuario.Email);
            return new UserToken
            {
                Token = token
            };
        }

            [HttpPost("login")]

            public async Task<ActionResult<UserToken>> Selecionar(LoginModel loginModel)

            {
                var existe = await _authenticateService.UserExists(loginModel.Email);
                if (!existe) // se for falso, retorna \/ 
                {
                    return Unauthorized("Usuário não existe!");   // validação do user
                }

            var result = await _authenticateService.AuthenticateAsync(loginModel.Email, loginModel.Password);
            if (!result) 
            {
                return Unauthorized("Usuário ou senha inválido.");
            }
            var usuario = await _authenticateService.GetUserByEmail(loginModel.Email);
            var token = _authenticateService.GenerateToken(usuario.Id, usuario.Email);

            return new UserToken
            {
                Token = token
            };
            }
        }
    }
