using SignalWell.Web.UI.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using DotNet.Framework.Core.Extends;
using System.Linq;
using System.Configuration;
namespace SignalWell.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "欢迎使用 ASP.NET MVC!";

            return View();
        }
        public ActionResult Details()
        {
            return View();
        }

        public ActionResult PDetails(string cid, string title, int? id = 0)
        {
            IList<Models.EDNF_Product_Class> categories = Business.Bus_Product_Class.GetAll() ?? new List<Models.EDNF_Product_Class>();

            ViewBag.Product = Business.Bus_Product_Item.GetModel(id.Value) ?? new Models.Entity_Product_Item()
            {
                PName = "",
                Description = "产品不存在或已被删除!"
            };

            ViewBag.IDList = GetProductCategoriesToIntArr(cid);
            ViewBag.leftid = cid;
            ViewBag.categories = categories;
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">cids</param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult Product(string id, string cid, string title, int? page = 1)
        {
            
            int totalCount = 0;
            int PageSize = 10;
            IList<Models.EDNF_Product_Class> categories = Business.Bus_Product_Class.GetAll() ?? new List<Models.EDNF_Product_Class>();

            if (id.IsInt())
            {
                var cName = Business.Bus_Product_Class.GetCategoryName(id.ToInt());
                if (!cName.IsNull())
                {
                    title = cName;
                }
            }

            IList<Models.Entity_Product_Item_Pager> products = new List<Models.Entity_Product_Item_Pager>();

            //取单个CID下的所有商品
            string ids = ids = GetProductCategories(id);
            products = Business.Bus_Product_Item.GetPagerData(ids, page.Value, PageSize, out totalCount) ?? new List<Models.Entity_Product_Item_Pager>();


            ViewBag.CategoryName = title;
            ViewBag.PageSize = PageSize;
            ViewBag.PageIndex = page.Value;
            ViewBag.TotalCount = totalCount;
            ViewBag.cid = id;
            ViewBag.IDList = GetProductCategoriesToIntArr(cid);
            ViewBag.leftid = cid;
            ViewBag.categories = categories;
            ViewBag.Products = products;
            return View();
        }

        private int[] GetProductCategoriesToIntArr(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                if (id.Contains("_"))
                {
                    int[] intArr = id.ToIntArr('_');
                    return intArr;
                }
                else
                {
                    if (id.IsInt())
                    {
                        return new int[] { id.ToInt() };
                    }
                }
            }
            return new int[0];
        }

        private static string GetProductCategories(string id)
        {
            string idIn = "";
            if (!string.IsNullOrWhiteSpace(id))
            {
                if (id.Contains("_"))
                {
                    int[] intArr = id.ToIntArr('_');
                    idIn = intArr.ToString(',');
                }
                else
                {
                    if (id.IsInt())
                    {
                        idIn = id;
                    }
                }
            }
            return idIn;
        }

        public ActionResult About(int? cid, int? id)
        {
            IList<Entity_About_LeftContent> articles = new List<Entity_About_LeftContent>();
            Entity_Content article = new Entity_Content()
            {
                ContentID = 0,
                Description = "数据读取错误..."
            };

            if (cid.HasValue && cid.Value > 0)
            {
                articles = Business.Bus_CMS_Content.GetListByClassID(cid.Value) ?? new List<Entity_About_LeftContent>();
            }

            if (id.HasValue && id.Value > 0)
            {
                article = Business.Bus_CMS_Content.GetModel(id.Value) ?? new Entity_Content();
            }

            ViewBag.CID = cid;
            ViewBag.ID = id;
            ViewBag.Categories = articles;
            ViewBag.Article = article;
            return View();
        }

        public ActionResult Links()
        {
            IList<Models.EDNF_CMS_FLinks> links = Business.Bus_CMS_FLinks.GetALL() ?? new List<EDNF_CMS_FLinks>();
            ViewBag.Links = links;
            return View();
        }
    }
}
