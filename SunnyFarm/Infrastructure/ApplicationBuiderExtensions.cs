namespace SunnyFarm.Infrastructure
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using SunnyFarm.Data;
    using SunnyFarm.Data.Models;
    using System.Linq;

    public static class ApplicationBuiderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var data = scopedServices.ServiceProvider.GetService<SunnyFarmDbContext>();

            data.Database.Migrate();

            SeedCategories(data);

            SeedProducts(data);

            return app;
        }

        private static void SeedProducts(SunnyFarmDbContext data)
        {
            if (data.Products.Any())
            {
                return;
            }

            var productPrice12Size900 = new PriceSizeCombination { Price = 12.00M, Size = 900 };
            var productPrice7Size450 = new PriceSizeCombination { Price = 7.00M, Size = 450 };

            var lipovMed = new Product { Name = "Пчелен мед - Липов", CategoryId = 1, Description = "Медът, приготвен от нектара на липите, е ценен заради уникалния си вкус и аромат.", ImageUrl = "https://nitrocdn.com/oyYpRBsrjiDmtpHGKdBttNtQywfuuusj/assets/static/optimized/rev-60c25b0/wp-content/uploads/2020/10/Linden-Honey-With-Honey-Dipper-1536x1024.jpg" };

            lipovMed.PriceSizeCombinations.Add(productPrice12Size900);
            lipovMed.PriceSizeCombinations.Add(productPrice7Size450);

            data.Products.Add(lipovMed);
            data.SaveChanges();

            var lavandulovMed = new Product { Name = "Пчелен мед - Лавандулов", CategoryId = 1, Description = "Този златист мед се характеризира с бавна кристализация и превъзходен вкус.", ImageUrl = "https://images.food52.com/jFaznsHFw5LOF12DkL6ZE0-COzk=/660x440/filters:format(webp)/0041a86c-ce51-48d9-9e64-322b2f9b44b2--Dollarphotoclub_68948199.jpg" };

            lavandulovMed.PriceSizeCombinations.Add(productPrice12Size900);
            lavandulovMed.PriceSizeCombinations.Add(productPrice7Size450);

            data.Products.Add(lavandulovMed);
            data.SaveChanges();

            var productPrice16Size900 = new PriceSizeCombination { Price = 16.00M, Size = 900 };
            var productPrice9Size450 = new PriceSizeCombination { Price = 9.00M, Size = 450 };

            var akacievMed = new Product { Name = "Пчелен мед - Акациев", CategoryId = 1, Description = "Акациевият мед се получава от нектара на цветето Robinia pseudoacacia. Има лек, почти прозрачен цвят и мощни антиоксиданти свойства.", ImageUrl = "https://cdn.shopify.com/s/files/1/1751/6601/products/Acacia_Honey_6d0b5219-a8eb-4de0-ac04-d021ee42d954_1400x.jpg?v=1606373543" };

            akacievMed.PriceSizeCombinations.Add(productPrice16Size900);
            akacievMed.PriceSizeCombinations.Add(productPrice9Size450);

            data.Products.Add(akacievMed);
            data.SaveChanges();

            var productPrice9Size900 = new PriceSizeCombination { Price = 9.00M, Size = 900 };
            var productPrice6Size450 = new PriceSizeCombination { Price = 6.00M, Size = 450 };

            var slunchogledovMed = new Product { Name = "Пчелен мед - Слънчогледов", CategoryId = 1, Description = "Характеризира се с мек вкус. Бързо се захаросва на стайна температура и това го прави подходящ за приготвяне на скраб-маски и ексфолиране на кожата.", ImageUrl = "https://ua.all.biz/img/ua/catalog/3067467.jpeg" };

            slunchogledovMed.PriceSizeCombinations.Add(productPrice9Size900);
            slunchogledovMed.PriceSizeCombinations.Add(productPrice6Size450);

            data.Products.Add(slunchogledovMed);
            data.SaveChanges();

            var productPrice18Size900 = new PriceSizeCombination { Price = 18.00M, Size = 900 };
            var productPrice11Size450 = new PriceSizeCombination { Price = 11.00M, Size = 450 };

            var manovMed = new Product { Name = "Пчелен мед - Манов", CategoryId = 1, Description = "Тъмнокафяв на цвят, с изразителен сладък аромат и богат микроелементен състав.", ImageUrl = "https://pliki.portalspozywczy.pl/i/12/05/18/120518_940.jpg" };

            manovMed.PriceSizeCombinations.Add(productPrice18Size900);
            manovMed.PriceSizeCombinations.Add(productPrice11Size450);

            data.Products.Add(manovMed);
            data.SaveChanges();

            var medBuket = new Product { Name = "Пчелен мед - Букет", CategoryId = 1, Description = "Събран от нектара на различни полски растения, този мед се характеризира с разнообразен състав, хранителни и профилактични качества, приятен аромат и сладък вкус.", ImageUrl = "https://www.begadistrictnews.com.au/images/transform/v1/crop/frm/R7sDaMurkWxVpij7Babdbr/b98471be-2d62-4ee0-91a4-cca573a89357.png/r0_0_1600_900_w1200_h678_fmax.jpg" };

            medBuket.PriceSizeCombinations.Add(productPrice12Size900);
            medBuket.PriceSizeCombinations.Add(productPrice7Size450);

            data.Products.Add(medBuket);
            data.SaveChanges();


            var medRapica = new Product { Name = "Пчелен мед - Рапица", CategoryId = 1, Description = "Рапичния мед е един от най-подходящите видове мед за деца, защото не предизвиква алергични реакции и съдържа витамин А.", ImageUrl = "https://nitrocdn.com/oyYpRBsrjiDmtpHGKdBttNtQywfuuusj/assets/static/source/rev-60c25b0/wp-content/uploads/2020/06/Rapeseed-Honey-1024x683.jpg" };

            medRapica.PriceSizeCombinations.Add(productPrice9Size900);
            medRapica.PriceSizeCombinations.Add(productPrice6Size450);

            data.Products.Add(medRapica);
            data.SaveChanges();

            var productPrice18Size500 = new PriceSizeCombination { Price = 18.00M, Size = 500 };
            var productPrice33Size450 = new PriceSizeCombination { Price = 33.00M, Size = 1000 };
            var productPrice390Size100 = new PriceSizeCombination { Price = 3.90M, Size = 100 };

            var pchelenPrashetc = new Product { Name = "Пчелен прашец", CategoryId = 2, Description = "Пчелният прашец съдържа почти всички хранителни вещества, необходими на хората. Това е най-богатият известен източник на витамини, минерали, аминокиселини, хормони, ензими и естествени антибиотици.", ImageUrl = "https://selfhacked.com/app/uploads/2020/03/Bee-pollen-1536x1020.jpg" };

            pchelenPrashetc.PriceSizeCombinations.Add(productPrice18Size500);
            pchelenPrashetc.PriceSizeCombinations.Add(productPrice33Size450);
            pchelenPrashetc.PriceSizeCombinations.Add(productPrice390Size100);

            data.Products.Add(pchelenPrashetc);
            data.SaveChanges();

            var productPrice2Size10 = new PriceSizeCombination { Price = 2.00M, Size = 10 };
            var productPrice550Size30 = new PriceSizeCombination { Price = 5.50M, Size = 30 };
            var productPrice18Size100 = new PriceSizeCombination { Price = 18.00M, Size = 100 };

            var propolis = new Product { Name = "Прополис", CategoryId = 3, Description = "Пчелният прополис притежава силни противомикробни, противовирусни, противорадиационни действия. Известен е като природен антибиотик и имуностимулатор при хората.", ImageUrl = "https://www.b-honey.gr/wp-content/uploads/propoli-400x400.jpg" };

            propolis.PriceSizeCombinations.Add(productPrice2Size10);
            propolis.PriceSizeCombinations.Add(productPrice550Size30);
            propolis.PriceSizeCombinations.Add(productPrice18Size100);

            data.Products.Add(propolis);
            data.SaveChanges();

            var productPrice165Size500 = new PriceSizeCombination { Price = 16.50M, Size = 500 };
            var productPrice950Size250 = new PriceSizeCombination { Price = 5.50M, Size = 250 };
            var productPrice490Size100 = new PriceSizeCombination { Price = 4.90M, Size = 100 };

            var pchelenVosuk = new Product { Name = "Пчелен восък", CategoryId = 4, Description = "Много привърженици на народната медицина ядат пчелен восък в умерени количества заради полезните му качества. Сам по себе си пчелният восък представлява лекарствено вещество, което може да регулира функциите на човешкото тяло.", ImageUrl = "https://www.beeswaxexpert.com/images/natural-beeswax.jpg" };

            pchelenVosuk.PriceSizeCombinations.Add(productPrice165Size500);
            pchelenVosuk.PriceSizeCombinations.Add(productPrice950Size250);
            pchelenVosuk.PriceSizeCombinations.Add(productPrice490Size100);

            data.Products.Add(pchelenVosuk);
            data.SaveChanges();

            var productPrice45Size50 = new PriceSizeCombination { Price = 45.00M, Size = 50 };
            var productPrice950Size10 = new PriceSizeCombination { Price = 9.50M, Size = 10 };

            var pchelnoMlecitce = new Product { Name = "Пчелно млечице", CategoryId = 5, Description = "Пчелното млечице (желе роял) е продукт, отделян от дейността на пчелите с полезни за организма на човека свойства.", ImageUrl = "https://cdn1.costatic.com/assets/img/guide_achat/articles/all-you-need-to-know-about-royal-jelly-s-natural-goodness_560x370px_d01fea9305929a9d_rs.jpg" };

            pchelnoMlecitce.PriceSizeCombinations.Add(productPrice45Size50);
            pchelnoMlecitce.PriceSizeCombinations.Add(productPrice950Size10);

            data.Products.Add(pchelnoMlecitce);
            data.SaveChanges();

            var productPrice26Size200 = new PriceSizeCombination { Price = 26.00M, Size = 200 };

            var sveshtListo = new Product { Name = "Свещ с бронзово листо", CategoryId = 6, Description = "Восъчната свещ, освен че подобрява качеството на въздуха в стаята, има ароматерапевтичен ефект, създава неподражаем уют, както и временен релаксиращ ефект върху организма.", ImageUrl = "https://www.urbanfolk.eu/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/n/a/natural_beeswax_candle-leaf_decoration-1.jpg" };

            sveshtListo.PriceSizeCombinations.Add(productPrice26Size200);
            data.Products.Add(sveshtListo);
            data.SaveChanges();

            var productPrice20Size150 = new PriceSizeCombination { Price = 20.00M, Size = 150 };

            var sveshtKosher = new Product { Name = "Свещ под формата на кошер", CategoryId = 6, Description = "Восъчната свещ, освен че подобрява качеството на въздуха в стаята, има ароматерапевтичен ефект, създава неподражаем уют, както и временен релаксиращ ефект върху организма.", ImageUrl = "https://raya.bg/dist/site_files/md/c2f63e6151797f32eaea309f437464c4.jpg" };

            sveshtKosher.PriceSizeCombinations.Add(productPrice20Size150);
            data.Products.Add(sveshtKosher);
            data.SaveChanges();

            var productPrice22Size200 = new PriceSizeCombination { Price = 22.00M, Size = 200 };

            var sveshtHexagon = new Product { Name = "Свещ под формата на хексагон", CategoryId = 6, Description = "Восъчната свещ, освен че подобрява качеството на въздуха в стаята, има ароматерапевтичен ефект, създава неподражаем уют, както и временен релаксиращ ефект върху организма.", ImageUrl = "https://cdn.shopify.com/s/files/1/0073/4193/2602/products/custom_resized_121ae7cc-0795-4393-abec-1ea576f11c0c_540x.jpg?v=1562288605" };

            sveshtHexagon.PriceSizeCombinations.Add(productPrice22Size200);
            data.Products.Add(sveshtHexagon);
            data.SaveChanges();

            var productPrice5Size100 = new PriceSizeCombination { Price = 5.00M, Size = 100 };

            var sapunMedVosuk = new Product { Name = "Сапун с мед и восък", CategoryId = 7, Description = "Произведен изцяло от натурални съставки, органично пчелен мед, бадемово масло, естествен глицерин, сода на растителна основа, стерилна вода, обогатен с френски парфюм. Не дразни кожата.", ImageUrl = "http://kanaskia.bg/f/products/v/0/a282f2dfac032b5bf761a6532b93fd77.jpeg" };

            sapunMedVosuk.PriceSizeCombinations.Add(productPrice5Size100);
            data.Products.Add(sapunMedVosuk);
            data.SaveChanges();

            var sapunMedPrashetc = new Product { Name = "Сапун с мед и прашец", CategoryId = 7, Description = "Произведен изцяло от натурални съставки, органично пчелен мед, бадемово масло, естествен глицерин, сода на растителна основа, стерилна вода, обогатен с френски парфюм. Не дразни кожата.", ImageUrl = "http://kanaskia.bg/f/products/v/0/5f4e1e2f44782fb3e01d72740dabd214.jpeg" };

            sapunMedPrashetc.PriceSizeCombinations.Add(productPrice5Size100);
            data.Products.Add(sapunMedPrashetc);
            data.SaveChanges();

            var sapunMedLavandula = new Product { Name = "Сапун с мед и лавандула", CategoryId = 7, Description = "Произведен изцяло от натурални съставки, органично пчелен мед, бадемово масло, естествен глицерин, сода на растителна основа, стерилна вода, обогатен с френски парфюм. Не дразни кожата.", ImageUrl = "http://kanaskia.bg/f/products/v/0/fad0e6a3f6c428ec68a4e37c46dc3a44.jpeg" };

            sapunMedLavandula.PriceSizeCombinations.Add(productPrice5Size100);
            data.Products.Add(sapunMedLavandula);
            data.SaveChanges();

            var productPrice650Size230 = new PriceSizeCombination { Price = 6.50M, Size = 230 };

            var medSRozoviLista = new Product { Name = "Пчелен мед с листенца от рози", CategoryId = 8, Description = "Най-бутиковият и неповторим продукт от България – мед със рози. Истинска експлозия от аромати.", ImageUrl = "https://i.pinimg.com/564x/99/fe/50/99fe507b009b97d9612b189d28e05384.jpg" };

            medSRozoviLista.PriceSizeCombinations.Add(productPrice650Size230);
            data.Products.Add(medSRozoviLista);
            data.SaveChanges();

            var productPrice105Size450 = new PriceSizeCombination { Price = 10.50M, Size = 450 };

            var medSOrehi = new Product { Name = "Пчелен мед с орехи", CategoryId = 8, Description = "Невероятно вкусна комбинация, укрепваща имунитета. Медът подобрява полезните свойства на орехите.", ImageUrl = "https://www.rachaelrayshow.com/sites/default/files/styles/1100x620/public/images/2017-05/5f22e82f3d2c279d57c76a0513276abb.jpg?itok=ou5NHDjJ" };

            medSOrehi.PriceSizeCombinations.Add(productPrice105Size450);
            data.Products.Add(medSOrehi);
            data.SaveChanges();

            var productPrice14Size250 = new PriceSizeCombination { Price = 14.00M, Size = 250 };

            var medSTahan = new Product { Name = "Пчелен мед с тахан от шамфъстък", CategoryId = 8, Description = "Поглезете сетивата си и се насладете на екзотичния вкус на печен шамфъстък и чист български мед. С неповторимата си мека и кремообразна консистенция, той ще се превърне в неизменна част от вашата закуска, следобедно хранене или самостоятелно, като сладка награда.", ImageUrl = "http://www.sweetpaulmag.com/1EatContent/images/2014/4997075_281271_Pistachio_01_01.jpg?Action=thumbnail&Width=512&Height=640&algorithm=fill_proportional" };

            medSTahan.PriceSizeCombinations.Add(productPrice14Size250);
            data.Products.Add(medSTahan);
            data.SaveChanges();

            var productPrice10Size350 = new PriceSizeCombination { Price = 10.00M, Size = 350 };

            var medSYadki = new Product { Name = "Пчелен мед с ядки", CategoryId = 8, Description = "Натуралният пчелен мед с ядки е с приятна текстура и вкус. Подходящ за следобедно похапване, когато се чуствате изморени.", ImageUrl = "https://swj0y6xl9l-flywheel.netdna-ssl.com/wp-content/uploads/2015/04/nuts3.jpg" };

            medSYadki.PriceSizeCombinations.Add(productPrice10Size350);
            data.Products.Add(medSYadki);
            data.SaveChanges();
        }

        private static void SeedCategories(SunnyFarmDbContext data)
        {
            if (data.Categories.Any())
            {
                return;
            }

            data.Categories.AddRange(new[]
            {
                new Category {Name = "Пчелен мед"},
                new Category {Name = "Пчелен прашец"},
                new Category {Name = "Прополис"},
                new Category {Name = "Пчелен восък"},
                new Category {Name = "Пчелно млечице"},
                new Category {Name = "Свещи"},
                new Category {Name = "Козметика"},
                new Category {Name = "Гурме"},
            });

            data.SaveChanges();
        }
    }
}
