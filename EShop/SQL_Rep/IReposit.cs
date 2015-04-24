using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.Models;
namespace EShop.SQL_Rep
{
    
    public interface IReposit
    {
        //получить список тестов
        List<TestName> ViewTestForUser { get; }
        List<TestName> ViewTestForAdmin { get; }
        #region прохождение теста
        //добавление результа прохождения теста
        int AddUserTest(int idTest, string USerName);
        //добавление ответа на вопрос теста
        bool AddUserAnswer(int idUserTest, int idQ, int idLA);
        //получить список вопросов
        IQueryable<QuestionName> GetQuest(int idTest);
        //получить  тест
        TestName GetTest(int idTest);
        //получить запись из таблицы результатов
        UserTest GetUserTest(int idUserTest);
        //получить вопрос 
        QuestionName GetQuestId(int idQ);
        //получить следующий вопрос
        QuestionName GetQuestNext(int idQ);
        //правильный ответ?
        int RightAnswer(int idLA);
        //конец прохождения теста, запись результата в таблицу
        bool EndQuest(int idQ);
        //подсчет результата запись втаблицу
        bool ResultCalc(int idUserTest, int idTest);
        #endregion
        #region результаты теста
        //получения списка результатов
        List<ResultUserTest> UserResultTest(string UserName);
        //список результатов по конкретному тесту
        IQueryable<UserTest> DetailResTest(int idTest, string username);
        #endregion
        #region админка
        //добавление вопроса
        bool AddQuest(QuestionName addquest);
        //добаление теста
        bool AddTest(TestName testname);
        //Редактирование теста
        bool EditTest(TestName testname);
        //Удаление теста
        bool DelTest(TestName testname);
        #endregion

    }
}
