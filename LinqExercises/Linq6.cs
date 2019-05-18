entity.Join(entity2, x => new {x.Field1, x.Field2},
                     y => new {y.Field1, y.Field2}, (x, y) => x);
					 
var result = from x in entity1
             from y in entity2
                 .Where(y => y.field1 == x.field1 && y.field2 == x.field2)

var itemNumbers = new HashSet<string>(GetAllowedSkus(Customer, Shipto, EnvironmentCode, AcceptLanguage, skusInSeries, Warehouse));

var selected = from s in series
               where s.Skus.Any(sku => itemNumbers.Contains(sku))
               select s;
               
var employee = _db.EMPLOYEEs
    .Where(x => x.EMAIL == givenInfo || x.USER_NAME == givenInfo);

var employee = _db.EMPLOYEEs
    .Where(x => x.EMAIL == givenInfo || x.USER_NAME == givenInfo)
    .Select(x => new { x.EMAIL, x.ID });                                    

//---------------------------------------------------------------------------
    Posts.Join(
    Post_metas,
    post => post.Post_id,
    meta => meta.Post_id,
    (post, meta) => new { Post = post, Meta = meta }
)


from p in Posts
join pm in Post_metas on p.Post_id equals pm.Post_id
select new { Post = p, Meta = pm }