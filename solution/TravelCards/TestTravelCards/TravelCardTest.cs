using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelCards;

namespace TestTravelCards
{
    [TestClass]
    public class TravelCardTest
    {
        [TestMethod]
        //Проверить, что решение подходит под пример из письма
        public void Way_FromCardsFromLetter_ShouldBeCorrect()
        {//arrange
            TravelPath tPath = new TravelPath();
            TravelCard Card = new TravelCard("Мельбурн", "Кельн");
            tPath.AddTravelCard(Card);
            Card = new TravelCard("Москва", "Париж");
            tPath.AddTravelCard(Card);
            Card = new TravelCard("Кельн", "Москва");
            tPath.AddTravelCard(Card);
            string expectedWay = "Мельбурн>Кельн Кельн>Москва Москва>Париж";
          //act
            tPath.Combine();
          //assert
            string actualWay = tPath.ToString();
            Assert.AreEqual(expectedWay, actualWay, true, "Путь не соответствует ожидаемому!");
        }
    }
}
