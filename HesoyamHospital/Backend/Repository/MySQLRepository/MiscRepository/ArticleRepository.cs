// File:    ArticleRepository.cs
// Author:  Geri
// Created: 24. maj 2020 17:38:19
// Purpose: Definition of Class ArticleRepository

using Backend.Model.UserModel;
using Backend.Repository.Abstract.MiscAbstractRepository;
using Backend.Repository.Abstract.UsersAbstractRepository;
using Backend.Repository.MySQLRepository.MySQL;
using Backend.Repository.MySQLRepository.MySQL.IdGenerator;
using Backend.Repository.MySQLRepository.MySQL.Stream;
using Backend.Repository.MySQLRepository.UsersRepository;
using Backend.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Repository.MySQLRepository.MiscRepository
{
    public class ArticleRepository : MySQLRepository<Article, long>, IArticleRepository, IEagerRepository<Article, long>
    {
        private const string ENTITY_NAME = "Article";

        public ArticleRepository(IMySQLStream<Article> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Article>())
        {
        }

        public new Article Create(Article article)
        {
            article.Date = DateTime.Now;
            return base.Create(article);
        }

        public IEnumerable<Article> GetArticleByAuthor(Employee author)
            => GetAll().ToList().Where(article => IsAuthorIdsEqual(article.Author, author));

        private bool IsAuthorIdsEqual(Employee authorId, Employee selectedAuthor)
            => authorId == null ? false : selectedAuthor.GetId().Equals(authorId.GetId());
    }
}