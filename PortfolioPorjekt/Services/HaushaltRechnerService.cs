using Microsoft.AspNetCore.Http.HttpResults;
using PortfolioPorjekt.IServices;
using PortfolioPorjekt.Resources;
using System.Collections.Generic;

namespace PortfolioPorjekt.Services
{
    public class HaushaltRechnerService : IHaushaltRechnerService
    {
        public readonly DatabaseContext _Database;

        public HaushaltRechnerService(DatabaseContext database)
        {
            _Database = database;
        }

        public Task<HaushaltRechnerResource> Create(HaushaltRechnerResource neuHaushaltRechner)
        {
            try
            {
                HaushaltRechnerResource newEntity = _Database.DbHaushaltRechner.Add(neuHaushaltRechner).Entity;
                
                _Database.SaveChanges();

                if (_Database.DbHaushaltRechner.Find(newEntity.Id) == null)
                {
                    throw new Exception("Failed to create new HaushaltRechner");
                }
                
                return Task.FromResult(newEntity);
            }
            catch
            {
                throw new Exception("Can't create new HaushaltRechner from Service");
            }
        }

        public Task<string> Delete(int id)
        {
            try
            {
                HaushaltRechnerResource? haushaltRechner = _Database.DbHaushaltRechner.Find(id);
                
                if (haushaltRechner != null)
                {
                    this._Database.DbHaushaltRechner.Remove(haushaltRechner);
                    _Database.SaveChanges();
                }
                else
                {
                    throw new Exception("Failed to Delete HaushaltRechner");
                }

                return Task.FromResult("Delete OK");
            }
            catch
            {
                throw new Exception("Can't Delete HaushaltRechner from Service");
            }
        }

        public Task<IEnumerable<HaushaltRechnerResource>> getAll()
        {
            try
            {
                IEnumerable<HaushaltRechnerResource> ListOfHauhaltRechner = _Database.DbHaushaltRechner.ToList();

                return Task.FromResult(ListOfHauhaltRechner);
            }
            catch
            {
                throw new Exception("Can't get all HaushaltRechner from Service");
            }
        }

        public Task<HaushaltRechnerResource> Update(int id, HaushaltRechnerResource updateHaushaltRechner)
        {
            try
            {
                HaushaltRechnerResource? haushaltRechner = _Database.DbHaushaltRechner.Find(id);

                if (haushaltRechner != null)
                {
                    haushaltRechner.Title = updateHaushaltRechner.Title;
                    haushaltRechner.Betrag = updateHaushaltRechner.Betrag;
                    haushaltRechner.Date = updateHaushaltRechner.Date;
                    haushaltRechner.EinnahmeType = updateHaushaltRechner.EinnahmeType;

                    _Database.SaveChanges();
                } 
                else
                {
                    throw new Exception("Failed to update HaushaltRechner");
                } 

                return Task.FromResult(haushaltRechner);
            }
            catch
            {
                throw new Exception("Can't update HaushaltRechner from Service");
            }
        }
    }
}
