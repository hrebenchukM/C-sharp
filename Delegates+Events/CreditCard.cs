//10. Events. Callback mechanism

//Издатель(CreditCard) определяет события и вызывает их.
//Подписчик (Show_Message, Color_Message) подписывается на эти события и выполняет действия, когда события срабатывают.

using Delegates_Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_Events
{
   // класс «Кредитная карточка»
    class CreditCard//(ИЗДАТЕЛЬ) - не знает о том, кто именно подписан на его события. Он просто генерирует события и уведомляет всех подписчиков
    {
        //Класс должен содержать: 
        protected string number; //Номер карты;
        protected string fullName; //ФИО владельца;
        protected string validityPeriod; //Срок действия карты;
        protected int pin; //PIN;
        protected int creditLimit; //Кредитный лимит;
        protected int sum; //Сумма денег




        //свойства  для доступа к полям
        public string Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }

        public string FullName
        {
            get
            {
                return fullName;
            }
            set
            {
                fullName = value;
            }
        }

        public string ValidityPeriod
        {
            get
            {
                return validityPeriod;
            }
            set
            {
                validityPeriod = value;
            }
        }

        public int Pin
        {
            get
            {
                return pin;
            }
            set
            {
                pin = value;
            }
        }
        public int CreditLimit
        {
            get
            {
                return creditLimit;
            }
            set
            {
                creditLimit = value;
            }
        }
        public int CurrentSum
        {
            get
            {
                return sum;
            }
            set
            {
                sum = value;
            }
        }



        //конструктор по умолчанию 
        public CreditCard()
        {
        }
        //конструктор с параметрами
        public CreditCard(string n, string f, string v, int p, int c,int s)
        {
            Console.WriteLine("Конструктор класса CreditCard");
            number = n;
            fullName = f;
            validityPeriod = v;
            pin = p;
            creditLimit= c;
            sum = s;    
        }


        //Делегат для событий которые будут вызываться при различных действиях (по факту делегат- абстракция указателя на функцию , тип, который хранит ссылку на метод)
        public delegate void AccountStateHandler(string message);//определения типа метода, который будет подписан на событие.одинаковая сигнатура должна быть (принимает строку и ничего не возвращает )


        //События типа AccountStateHandler которые будут срабатывать при изменении состояния
        // событие может быть связано с любыми методами, подходящими под делегат AccountStateHandler
        //динамический привязыв метода к событию во время выполнения программы
        public event AccountStateHandler Add; //Пополнение счёта;
        public event AccountStateHandler Del;  //Расход денег со счёта;
        public event AccountStateHandler StartCredit;  //Старт использования кредитных денег;
        public event AccountStateHandler AchievingSum;   //Достижение заданной суммы денег;
        public event AccountStateHandler NewPin;  //Смена PIN.



        //Методы
        //Пополнение счёта;
        public void Put(int _sum)
        {
            sum += _sum;
            //ИЗДАТЕЛЬ вызывает событие Add  с помощью Invoke и передает сообщение с информацией всем подписанным на событие  обработчикам (ПОДПИСЧИКАМ)

            Add?.Invoke("Пополнение на сумму:" + _sum.ToString() + "Баланс:" + sum.ToString());
           

            if(sum>=49550)
            {
                AchievingSum?.Invoke("Достижение! Вы достигли заданной суммы 49550₴." + "Баланс: " + sum.ToString()); //Достижение заданной суммы денег;
            }
        }

        //Расход денег со счёта;
        public void Withdraw(int _sum)
        {
            if (_sum <= sum)
            {
                sum -= _sum;
                Del?.Invoke("Сумма " + _sum.ToString() + " снята со счета." + "Баланс:" + sum.ToString());
            }
            else if (_sum <= sum + creditLimit)//Старт использования кредитных денег;
            {
                sum -= _sum;
                StartCredit?.Invoke("Старт использования кредитных денег. Долг: " + (-sum).ToString());
                Del?.Invoke("Сумма " + _sum.ToString() + " снята со счета с использованием кредитных денег." + "Баланс:" + sum.ToString());
            }
            else
            {
                Del?.Invoke("Недостаточно денег на счете и кредитном лимите");
            }
        }
       
        public void ChangePinCode(int newPin)
        { 
            pin=newPin;
            NewPin?.Invoke("PIN изменен на:"+ newPin.ToString());
        }



    }

}
