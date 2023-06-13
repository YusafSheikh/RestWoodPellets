using Microsoft.Extensions.FileProviders;
using System.Xml.Linq;
using WoodPelletLib; // Antager, at dette namespace indeholder WoodPellet-klassen

namespace RestWoodPellets.Repository
{
    public class WoodPelletRepository
    {
        private int _nextID; // Variabel til at holde styr på det næste tilgængelige ID
        private List<WoodPellet> woodPellets; // Liste til at gemme WoodPellet-objekter

        public WoodPelletRepository()
        {
            _nextID = 1; // Initialiserer _nextID til 1 
                         // Når en ny instans af Repository-klassen oprettes, initialiseres _nextID til 1.
                         // Når der tilføjes et nyt WoodPellet-objekt til listen, bliver dets Id-egenskab sat til værdien af _nextID, og derefter øges værdien af _nextID.
                        //Ved at have et unikt ID til hvert WoodPellet - objekt gør det det muligt at identificere og arbejde med objekterne individuelt.For eksempel kan man finde et WoodPellet - objekt baseret på dets ID, opdatere eller slette det.
                        woodPellets = new List<WoodPellet>()
            {
                // Initialiserer woodPellets-listen med nogle eksempeldata
                new WoodPellet() {Id = _nextID++, Brand ="Brown Wood", Price=12900, Quality=25},
                new WoodPellet() {Id = _nextID++, Brand="Small pieces Wood", Price=5500, Quality=6000},
                new WoodPellet() {Id = _nextID++, Brand="Large tons of wood", Price=10000, Quality=64},
                new WoodPellet() {Id = _nextID++, Brand="Canadian Trees", Price=1500, Quality=605},
                new WoodPellet() {Id = _nextID++, Brand="African tree oil", Price=232, Quality=2},
            };
        }

        public List<WoodPellet> GetAll()
        {
            // Returnerer en ny liste, der indeholder en kopi af woodPellets-listen
            return new List<WoodPellet>(woodPellets);
        }

        public List<WoodPellet> GetByBrand(string brand)
        {
            // Filter woodPellets list by brand and return matching wood pellets
            return woodPellets.Where(woodPellet => woodPellet.Brand.ToLower() == brand.ToLower()).ToList();
        }

        public List<WoodPellet> GetSortedByQuality()
        {
            // Order by quality
            return woodPellets.OrderBy(woodPellet => woodPellet.Quality).ToList();
        }

        public WoodPellet GetById(int Id)
        {
            // Finder og returnerer det første WoodPellet-objekt med det angivne Id
            return woodPellets.Find(woodPellet => woodPellet.Id == Id);
        }

        public WoodPellet Add(WoodPellet NewWoodPellet)
        {
            // Tilføjer et nyt WoodPellet-objekt til woodPellets-listen med et unikt Id
            NewWoodPellet.Id = _nextID++;
            woodPellets.Add(NewWoodPellet);
            return NewWoodPellet;
        }

        public WoodPellet? Delete(int Id) 
        {
            // Finder det WoodPellet-objekt, der matcher det angivne Id
            WoodPellet? foundWoodPellet = GetById(Id);

            // Hvis intet WoodPellet-objekt blev fundet, returneres null
            if (foundWoodPellet == null)
            {
                return null;
            }

            // Fjerner det fundne WoodPellet-objekt fra woodPellets-listen
            woodPellets.Remove(foundWoodPellet);
            return foundWoodPellet;
        }

        public WoodPellet? Update(int Id, WoodPellet updates)
        {
            WoodPellet? foundWoodPellets = GetById(Id);
            if (foundWoodPellets == null)
            {
                return null;
            }
            foundWoodPellets.Brand = updates.Brand;
            foundWoodPellets.Price = updates.Price;
            foundWoodPellets.Id = _nextID++;
            foundWoodPellets.Quality = updates.Quality;
            return foundWoodPellets;
        }

        public WoodPellet UpdateMethod(int id, WoodPellet updatedWoodPellet)
        {
            WoodPellet existingWoodPellet = woodPellets.FirstOrDefault(wp => wp.Id == id);
            if (existingWoodPellet != null)
            {
                existingWoodPellet.Brand = updatedWoodPellet.Brand;
                existingWoodPellet.Price = updatedWoodPellet.Price;
                existingWoodPellet.Quality = updatedWoodPellet.Quality;
            }
            return existingWoodPellet;
        }
    }
}
