// File:    ArticleService.cs
// Author:  Geri
// Created: 7. maj 2020 12:01:08
// Purpose: Definition of Class ArticleService

using System;
using System.Collections.Generic;
using System.Linq;

using System.Xml;

using Backend.Exceptions;

using Backend.Model.UserModel;
using Backend.Repository.Abstract.MiscAbstractRepository;
using Backend.Repository.MySQLRepository.MiscRepository;

namespace Backend.Service.MiscService
{
    public class ArticleService : IService<Article, long>
    {

        private ArticleRepository _articleRepository;

        public ArticleService(ArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public IEnumerable<Article> GetArticleByAuthor(Employee author)
            => _articleRepository.GetArticleByAuthor(author);

        public IEnumerable<Article> GetAll()
            => _articleRepository.GetAllEager();

        public Article GetByID(long id)
            => GetAll().SingleOrDefault(article => article.GetId() == id);

        public Article Create(Article entity)
        {
            Validate(entity);
            return _articleRepository.Create(entity);
        }


        public void Update(Article entity)
        {
            Validate(entity);
            _articleRepository.Update(entity);
        }

        public void Delete(Article entity)
            => _articleRepository.Delete(entity);

        public void Validate(Article entity)
        {

            if (entity.Author == null)
            {
                throw new ArticleServiceException("Author is not set!");
            }
        }
    }
}