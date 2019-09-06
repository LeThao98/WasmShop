using System.Web.Mvc;
using WasmShop.Service;
using WasmShop.Web.Models;

namespace WasmShop.Web.Infrastructure
{
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext,
 ModelBindingContext bindingContext)
        {
            // get the Cart from the session
            CartViewModel cart = null;

            if (controllerContext.HttpContext.Session != null)
            {
                cart = (CartViewModel)controllerContext.HttpContext.Session[sessionKey];
            }
            // create the Cart if there wasn't one in the session data
            if (cart == null)
            {
                cart = new CartViewModel();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }
            }
            // return the cart
            return cart;
        }
    }
}