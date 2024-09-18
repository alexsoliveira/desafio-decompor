using AutoMapper;
using Desafio.Decompor.Api.ViewModels;
using Desafio.Decompor.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using DomainObject = Desafio.Decompor.Business.Domain;

namespace Desafio.Decompor.Api.Controllers
{
    [Route("api/v1/decompor")]
    public class DecomporController : MainController
    {
        private readonly IDecomporService _decomporService;        
        private readonly IMapper _mapper;

        public DecomporController(IDecomporService decomporService,                             
                             IMapper mapper,
                             INotificador notificador) : base(notificador)
        {
            _decomporService = decomporService;            
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResultadoViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public ActionResult<ResultadoViewModel> ObterCalculo(DecomporViewModel decomporViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var decompor = _mapper.Map<DomainObject.Decompor>(decomporViewModel);

            var obterNumeroDivisores = _decomporService.ObterListaNumerosDivisores(decompor);

            var obterNumeroPrimos = _decomporService.ObterListaDivisoresPrimos(decompor);            

            var resultado = new ResultadoViewModel(obterNumeroDivisores, obterNumeroPrimos);

            return CustomResponse(HttpStatusCode.OK, resultado);
        }
    }
}