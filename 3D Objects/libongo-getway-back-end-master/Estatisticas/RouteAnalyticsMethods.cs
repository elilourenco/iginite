using System.Linq;
using System;
using System.Collections.Generic;
using libongo.Helpers;
using libongo.Models;

namespace libongo.Estatisticas
{

  public class RouteAnalyticsMethods
  {

    public ContextServiceLocator contextServiceLocator;

    public RouteAnalyticsMethods(ContextServiceLocator _contextServiceLocator)
    {
      contextServiceLocator = _contextServiceLocator;
    }

    /*
    public RouteAnalytics addtestatic(RouteAnalytics dados)
    {
     
      return contextServiceLocator.Repository.Add<RouteAnalytics>(dados);
    }
    */
    
    public RouteAnalytics addtestatic(RouteAnalytics dados,string dadoscanal, string metodo)
    {
      
      var Canals = new Canal();
      var Canal = contextServiceLocator.Repository.selectOne<Canal>(Canals,dadoscanal).FirstOrDefault();


      var Methodss = new Methods();
      var Methods = contextServiceLocator.Repository.selectOne<Methods>(Methodss,metodo).FirstOrDefault();


      dados.MethodId=Methods.Id;
      dados.CanalId=Canal.Id;
      return contextServiceLocator.Repository.Add<RouteAnalytics>(dados);
    }
    

    public  IEnumerable<RouteAnalytics> getestatic(RouteAnalytics dados,string id,RoutesCanal valorRoutesCanal, string idRoutesCanal,Methods valorRoutesMethods,string idMehod)
    {
     
      var RoutesCanal = contextServiceLocator.Repository.selectOne<RoutesCanal>(valorRoutesCanal, idRoutesCanal).FirstOrDefault();
      var Methods = contextServiceLocator.Repository.selectOne<Methods>(valorRoutesMethods, idMehod).FirstOrDefault();

      dados.MethodId=Methods.Id;
      dados.CanalId=RoutesCanal.Id;

      return contextServiceLocator.Repository.selectOne<RouteAnalytics>(dados, id);
    }
  }
}