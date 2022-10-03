# BoynerCase
Proje Dizininde komut istemcisi ile aşağıdaki komutu çalıştırınız

docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d

bu komutla beraber .net 6 web api , sql ve redis containerları ayağa kalkacaktır.

 [http://localhost:5002/swagger/index.html](http://localhost:5002/swagger/index.html)  üzerinde wep api projesinin swagger sayfasına ulaşabilirsiniz.
 
 Attirbute ve AttributeValue ekleme ve listeleme endpoinleri yapılmadı.
 
 Uygulama ayağa kalkarken default olarak aşağıdaki şekilde Attribute ve AttributeValue tablosunu create ettim.
 
     #Attribute Tablosu
         
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
               
               
               
               #AttributeValue Tablosu
               
               new AttributeValue
                   {
                       Id = 1,
                       Name = "Fabrika",
                       AttributeId = 1,
                       AddedDate = DateTime.Now,
                       IsActive = true,
                       ModifiedDate = DateTime.Now
                   },
                  new AttributeValue
                  {
                      Id = 2,
                      Name = "U.S. Polo",
                      AttributeId = 1,
                      AddedDate = DateTime.Now,
                      IsActive = true,
                      ModifiedDate = DateTime.Now
                  },
                 new AttributeValue
                 {
                     Id = 3,
                     Name = "XL",
                     AttributeId = 2,
                     AddedDate = DateTime.Now,
                     IsActive = true,
                     ModifiedDate = DateTime.Now
                 },
                 new AttributeValue
                 {
                     Id = 4,
                     Name = "L",
                     AttributeId = 2,
                     AddedDate = DateTime.Now,
                     IsActive = true,
                     ModifiedDate = DateTime.Now
                 },
                  new AttributeValue
                  {
                      Id = 5,
                      Name = "Yeşil",
                      AttributeId = 3,
                      AddedDate = DateTime.Now,
                      IsActive = true,
                      ModifiedDate = DateTime.Now
                  },
                  new AttributeValue
                  {
                      Id = 6,
                      Name = "Siyah",
                      AttributeId = 3,
                      AddedDate = DateTime.Now,
                      IsActive = true,
                      ModifiedDate = DateTime.Now
                  },
                 new AttributeValue
                 {
                     Id = 7,
                     Name = "4 inc",
                     AttributeId = 4,
                     AddedDate = DateTime.Now,
                     IsActive = true,
                     ModifiedDate = DateTime.Now
                 },
                 new AttributeValue
                 {
                     Id = 8,
                     Name = "5 inc",
                     AttributeId = 4,
                     AddedDate = DateTime.Now,
                     IsActive = true,
                     ModifiedDate = DateTime.Now
                 }, new AttributeValue
                 {
                     Id = 9,
                     Name = "Android",
                     AttributeId = 5,
                     AddedDate = DateTime.Now,
                     IsActive = true,
                     ModifiedDate = DateTime.Now
                 },
                 new AttributeValue
                 {
                     Id = 10,
                     Name = "iOS",
                     AttributeId = 5,
                     AddedDate = DateTime.Now,
                     IsActive = true,
                     ModifiedDate = DateTime.Now
                 },
                 new AttributeValue
                 {
                     Id = 11,
                     Name = "Erkek",
                     AttributeId = 6,
                     AddedDate = DateTime.Now,
                     IsActive = true,
                     ModifiedDate = DateTime.Now
                 },
                 new AttributeValue
                 {
                     Id = 12,
                     Name = "Kadın",
                     AttributeId = 6,
                     AddedDate = DateTime.Now,
                     IsActive = true,
                     ModifiedDate = DateTime.Now
                 }
