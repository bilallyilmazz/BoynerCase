# BoynerCase
Proje Dizininde komut istemcisi ile aşağıdaki komutu çalıştırınız

docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d

bu komutla beraber .net 6 web api , sql ve redis containerları ayağa kalkacaktır.

 [http://localhost:5002/swagger/index.html](http://localhost:5002/swagger/index.html)  üzerinde wep api projesinin swagger sayfasına ulaşabilirsiniz.
 
 Attirbute ekleme ve listeleme endpoinleri yapılmadı.
 
 Uygulama ayağa kalkarken default olarak aşağıdaki şekilde Attribute tablosunu create ettim.
 
 
         
                   new Attribute
                   {
                       Id = 1,
                       Name = "Brand",
                       AddedDate = DateTime.Now,
                       IsActive = true,

                       ModifiedDate = DateTime.Now
                   },
                   
                  new Attribute
                  {
                      Id = 2,
                      Name = "Size",
                      AddedDate = DateTime.Now,
                      IsActive = true,
                      ModifiedDate = DateTime.Now
                  },
                  new Attribute
                  {
                      Id = 3,
                      Name = "Color",
                      AddedDate = DateTime.Now,
                      IsActive = true,
                      ModifiedDate = DateTime.Now
                  },
                  new Attribute
                  {
                      Id = 4,
                      Name = "Screen Size",
                      AddedDate = DateTime.Now,
                      IsActive = true,
                      ModifiedDate = DateTime.Now
                  },
                  new Attribute
                  {
                      Id = 5,
                      Name = "OS",
                      AddedDate = DateTime.Now,
                      IsActive = true,
                      ModifiedDate = DateTime.Now
                  },
                  new Attribute
                  {
                      Id = 6,
                      Name = "Gender",
                      AddedDate = DateTime.Now,
                      IsActive = true,
                      ModifiedDate = DateTime.Now
                  }
               ); 
