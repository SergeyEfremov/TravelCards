using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCards
{
    #region Карточка путешественника
    public class TravelCard
    {
        //закрытые поля и открытые свойства

        private string _cityStart;
        private string _cityDest;

        public string CityStart
        {
            get { return _cityStart; }
            set { _cityStart = value; }
        }
        public string CityDest
        {
            get { return _cityDest; }
            set { _cityDest = value; }
        }

        public TravelCard(string сityStartName, string cityDestName)
        {
            CityStart = сityStartName;
            CityDest = cityDestName;
        }
    }
    #endregion
    #region Маршрут путешественника
    public class TravelPath
    {
        //Список карточек
        private List<TravelCard> _cardList;

        #region Получение первой карточки (старт маршрута) - сложность O(n(n-1))
        //Проверка, является ли карточка первой в маршруте - сложность O(n-1)
        private bool IsFirstCardInPath(TravelCard сard)
        {
            bool isFirstCard = true;

            foreach (TravelCard travCard in _cardList)
            {
                if ((travCard != сard) && string.Equals(travCard.CityDest.ToUpper(), сard.CityStart.ToUpper(),
                        StringComparison.Ordinal))
                {
                    isFirstCard = false;
                } 
            }

            return isFirstCard;
        }
        //Получение первой карточки в маршруте -сложность O(n(n-1))
        private TravelCard FirstCard()
        {
            foreach (TravelCard сard in _cardList)
            {
                if (IsFirstCardInPath(сard))
                {
                    return сard;
                }
            }
            return null;
        }
        #endregion  
        #region Получение следующей карточки в маршруте -сложность O(n-i) = O(_cardList.Count)
        private TravelCard NextCard(TravelCard card)
        {
            foreach (TravelCard travCard in _cardList)
            {
                if ((travCard != card) && (string.Equals(travCard.CityStart.ToUpper(), card.CityDest.ToUpper(),
                        StringComparison.Ordinal)))
                {
                    return travCard;
                }
            }
            return null;
        }
        #endregion
        #region Добавление карточки в список
        public void AddTravelCard(TravelCard card)
        {
            _cardList.Add(card);
        }
        #endregion
        #region Основной метод - составление маршрута(сортировка карточек) - сложность ~ O(1.5n^2)
        public void Combine()
        {
            List<TravelCard> newCardList = new List<TravelCard>();
            TravelCard card = FirstCard();
            newCardList.Add(card);
            card = NextCard(card);
            while (card != null) 
            {
                newCardList.Add(card);
                _cardList.Remove(card);
                card = NextCard(card);
            }
            _cardList = newCardList;
        }
        #endregion
        #region Показ маршрута
        public override string ToString()
        {
            string travelPath = "";
            foreach (TravelCard t in _cardList)
            {
                travelPath = travelPath + " " + t.CityStart + ">" + t.CityDest;
                travelPath = travelPath.Trim();
            }
            return travelPath; 
        }
        #endregion
        #region Конструктор класса
        public TravelPath()
        {
           _cardList = new List<TravelCard>();
        }
        #endregion
    }
    #endregion
}
