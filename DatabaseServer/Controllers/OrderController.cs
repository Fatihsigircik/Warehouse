using System;
using DAL;
using DatabaseServer.Filters;
using DatabaseServer.Helper;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using DatabaseServer.Models;

namespace DatabaseServer.Controllers
{
    [JwtAuthentication]
    public class OrderController : ApiController
    {
        public IHttpActionResult Get()
        {
            var orders = new Repository<Order>().Get().ToList();
            return Json(GeneralHelper.GetMessage<Order>(orders, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"{orders.Count} Adet Kayıt Bulundu."));
        }
        public IHttpActionResult GetView()
        {
            var orders = new Repository<VwOrder>().Get().ToList();
            return Json(GeneralHelper.GetMessage<VwOrder>(orders, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"{orders.Count} Adet Kayıt Bulundu."));
        }
        public async Task<IHttpActionResult> GetViewOrderCodeStartWith(string orderCode)
        {
            var orders = await new Repository<VwOrder>().GetByWhereExpression(q => q.OrderCode.StartsWith(orderCode)).ToListAsync();
            return Json(GeneralHelper.GetMessage<VwOrder>(orders, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"{orders.Count} Adet Kayıt Bulundu."));
        }
        public async Task<IHttpActionResult> GetView(int skip, int take)
        {
            var orders = await new Repository<VwOrder>().GetBySkipAndTake(skip, take);
            return Json(GeneralHelper.GetMessage<VwOrder>(orders, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"{orders.Count} Adet Kayıt Bulundu."));
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var order = await new Repository<Order>().GetById(id);
            var retVal = (object)order ?? new { };
            return Json(GeneralHelper.GetMessage<Order>(new List<object> { retVal }, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

        public async Task<IHttpActionResult> GetFullOrder(int id)
        {
            var order = await new Repository<Order>().GetById(id);
            var detail = new Repository<OrderDetail>().GetByProperty("OrderId", id);
            var ord = GeneralHelper.ConvertType<FullOrder>(order);
            ord.OrderDetails = detail;
            var retVal = (object)ord ?? new { };
            return Json(GeneralHelper.GetMessage<Order>(new List<object> { retVal }, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

        [HttpGet]
        public IHttpActionResult GetByCode(string code)
        {
            var orders = new Repository<Order>().GetByProperty("OrderCode", code);
            return Json(GeneralHelper.GetMessage<Order>(orders, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(Order order)
        {
            var retVal = await new Repository<Order>().Add(order);
            return Json(retVal);
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostFull(FullOrder order)
        {
            var ord = GeneralHelper.ConvertType<Order>(order);
            var repo = new Repository<Order>();
            using (var ent = repo.Entity)
            {
                using (DbContextTransaction tran = ent.Database.BeginTransaction())
                {
                    try
                    {
                        var o = ent.Order.Add(ord);
                        ent.SaveChanges();
                        foreach (OrderDetail detail in order.OrderDetails)
                        {
                            detail.OrderId = o.OrderId;
                            ent.OrderDetail.Add(detail);
                        }

                        ent.SaveChanges();
                        tran.Commit();
                        return Json(o);
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        return Json($"{{\"Hata\":{e.Message}}}");
                    }
                   
                }
            }


            //var retVal = await repo.Add(order);
            
        }


        [HttpPost]
        public async Task<IHttpActionResult> PostList([FromBody] List<Order> orders)
        {
            var retVal = await new Repository<Order>().AddList(orders);
            return Json(retVal);
        }

        [HttpPut]
        public IHttpActionResult Update(Order order)
        {
            var retVal = new Repository<Order>().Update(order);
            return Json(GeneralHelper.GetMessage<Order>(null, Messages.SUCCESS_UPDATE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Güncellendi."));
        }
        [HttpPut]
        public IHttpActionResult UpdateOrder(FullOrder order)
        {
            
            //var ord = GeneralHelper.ConvertType<Order>(order);
            var repo = new Repository<Order>();

            

            using (var ent = repo.Entity)
            {
                var finded = ent.Order.Find(order.OrderId);
                GeneralHelper.SetFields(order,ref finded);
                using (DbContextTransaction tran = ent.Database.BeginTransaction())
                {
                    try
                    {
                       // var o = ent.Order.Add(ord);
                        ent.SaveChanges();
                        ent.OrderDetail.RemoveRange(ent.OrderDetail.Where(q => q.OrderId == order.OrderId));
                        foreach (OrderDetail detail in order.OrderDetails)
                        {
                            
                            ent.OrderDetail.Add(detail);
                        }

                        ent.SaveChanges();
                        tran.Commit();
                        return Json(GeneralHelper.GetMessage<Order>(new int[] { 1}, Messages.SUCCESS_UPDATE, GeneralHelper.StatusType.Success, $"{1} Adet Kayıt Güncellendi."));
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        return Json($"{{\"Hata\":{e.Message}}}");
                    }

                }
            }
        }
        [HttpPut]
        public async Task<IHttpActionResult> UpdateList([FromBody] List<Order> orders)
        {
            var retVal = await new Repository<Order>().UpdateList(orders);
            return Json(GeneralHelper.GetMessage<Order>(null, Messages.SUCCESS_UPDATE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Güncellendi."));
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {

            var repo = new Repository<Order>();



            using (var ent = repo.Entity)
            {
                
                using (DbContextTransaction tran = ent.Database.BeginTransaction())
                {
                    try
                    {
                        var finded = ent.Order.Find(id);
                        // var o = ent.Order.Add(ord);
                        ent.Order.Remove(finded);
                        //ent.SaveChanges();
                        ent.OrderDetail.RemoveRange(ent.OrderDetail.Where(q => q.OrderId == id));

                        ent.SaveChanges();
                        tran.Commit();
                        return Json(GeneralHelper.GetMessage<Order>(new int[] {1}, Messages.SUCCESS_UPDATE,
                            GeneralHelper.StatusType.Success, $"{1} Adet Kayıt Silindi."));
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        return Json($"{{\"Hata\":{e.Message}}}");
                    }

                }
            }

        
        //return Json(GeneralHelper.GetMessage<Order>(null, Messages.SUCCESS_DELETE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Silindi."));




        }

        //[HttpDelete]
        //public async Task<IHttpActionResult> DeleteByCode([FromUri] string code)
        //{
        //    var retVal = await new Repository<Order>().DeleteByField("OrderCode", code);
        //    return Json(GeneralHelper.GetMessage<Order>(null, Messages.SUCCESS_DELETE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Silindi."));
        //}
    }
}