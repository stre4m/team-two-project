﻿using KartowkaMarkowkaHub.Core.Domain;

namespace KartowkaMarkowkaHub.Data.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly HubContext _db;
        private GenericRepository<Product>? _productRepository;
        private GenericRepository<Order>? _orderRepository;

        public UnitOfWork(HubContext db)
        {
            _db = db;
        }

        public GenericRepository<Product> ProductRepository {
            get {
                if (_productRepository == null)
                    _productRepository = new GenericRepository<Product>(_db);
                return _productRepository;
            } 
        }

        public GenericRepository<Order> OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                    _orderRepository = new GenericRepository<Order>(_db);
                return _orderRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}