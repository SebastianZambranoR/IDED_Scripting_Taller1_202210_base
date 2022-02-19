using System.Collections.Generic;

namespace TestProject1
{
    internal class TestMethods
    {
        internal enum EValueType
        {
            Two,
            Three,
            Five,
            Seven,
            Prime
        }

        internal static Stack<int> GetNextGreaterValue(Stack<int> sourceStack)
        {
            Stack<int> result = new Stack<int>();
            List<int> temp = new List<int>();
            int count = sourceStack.Count;
            for (int i = 0; i < count; i++)
            {
                temp.Add(sourceStack.Pop());
            }
            temp.Reverse();

            result.Push(-1);
            int num = 0;
            for (int i = 1; i < temp.Count-1; i++)
            {

                for (int j = i + 1 ; j < temp.Count ; j++)
                {
                    if (num < temp[j])
                    {
                        num = temp[j];
                    }
                }
                if(temp[i] < num)
                {
                    result.Push(num);
                }
                else
                {
                    result.Push(-1);
                }

            }

            result.Push(-1);


            return result;
        }

        internal static Dictionary<int, EValueType> FillDictionaryFromSource(int[] sourceArr)
        {
            Dictionary<int, EValueType> result = new Dictionary<int, EValueType>();

            for (int i = 0; i < sourceArr.Length; i++)
            {
                result.Add(sourceArr[i], CalcularMultiplicidad(sourceArr[i]));
            }
            return result;
        }

        internal static EValueType CalcularMultiplicidad(int num)
        {
            EValueType value = EValueType.Prime;
            if((num % 2) == 0)
            {
               value = EValueType.Two;
            }else if ((num % 3) == 0)
            {
                value = EValueType.Three;
            }else if ((num % 5) == 0)
            {
                value = EValueType.Five;
            }else if ((num % 7) == 0)
            {
                value = EValueType.Seven;
            }
            return value;
        }

        internal static int CountDictionaryRegistriesWithValueType(Dictionary<int, EValueType> sourceDict, EValueType type)
        {
            int result = 0;
            foreach (var s in sourceDict.Values)
            {
                if(s == type)
                {
                    result++;
                }
            }
            return result;
        }

        internal static Dictionary<int, EValueType> SortDictionaryRegistries(Dictionary<int, EValueType> sourceDict)
        {
            Dictionary<int, EValueType> result = new Dictionary<int, EValueType>();
            List<int> keylist = new List<int>();
            foreach (var s in sourceDict.Keys)
            {
                keylist.Add(s);
            }

            result = FillDictionaryFromSource(OrdenarLlaves(keylist).ToArray());

            return result;
        }

        internal static List<int> OrdenarLlaves(List<int> keys)
        {
            for (int i = 0; i < keys.Count; i++)
            {
                for (int j = 0; j < keys.Count; j++)
                {
                    if(keys[i] > keys[j])
                    {
                        int temp = keys[i];
                        keys[i] = keys[j];
                        keys[j] = temp;
                    }
                }
            }

            return keys;
        }

        internal static Queue<Ticket>[] ClassifyTickets(List<Ticket> sourceList)
        {
            Queue<Ticket>[] result = new Queue<Ticket>[3];
            List<Ticket> paymentList = new List<Ticket>();
            List<Ticket> SubscriptionList = new List<Ticket>();
            List<Ticket> CancellationsList = new List<Ticket>();
            int originalCount = sourceList.Count;
            for (int i = 0; i < sourceList.Count; i++)
            {
                if(sourceList[i].RequestType == Ticket.ERequestType.Payment)
                {
                    paymentList.Add(sourceList[i]);

                }else if (sourceList[i].RequestType == Ticket.ERequestType.Subscription)
                {
                    SubscriptionList.Add(sourceList[i]);

                }
                else if (sourceList[i].RequestType == Ticket.ERequestType.Cancellation)
                {
                    CancellationsList.Add(sourceList[i]);

                }
            }
            List<Ticket> OrdenedpaymentList = OrdenarTickets(paymentList);
            List<Ticket> OrdenedSubscriptionList = OrdenarTickets(SubscriptionList);
            List<Ticket> OrdenedCancellationsList = OrdenarTickets(CancellationsList);
            OrdenedpaymentList.Reverse();
            OrdenedSubscriptionList.Reverse();
            OrdenedCancellationsList.Reverse();
            Queue<Ticket> paymentQueue = new Queue<Ticket>();
            Queue<Ticket> subscriptionQueue = new Queue<Ticket>();
            Queue<Ticket> cancellationQueue = new Queue<Ticket>();

            for (int i = 0; i < OrdenedpaymentList.Count; i++)
            {
                paymentQueue.Enqueue(OrdenedpaymentList[i]);
       
            }
            for (int i = 0; i < OrdenedSubscriptionList.Count; i++)
            {
                subscriptionQueue.Enqueue(OrdenedSubscriptionList[i]);
            }
            for (int i = 0; i < OrdenedCancellationsList.Count; i++)
            {
                cancellationQueue.Enqueue(OrdenedCancellationsList[i]);
            }

            result[0] = paymentQueue;
            result[1] = subscriptionQueue;
            result[2] = cancellationQueue;
            return result;
        }

        internal static List<Ticket> OrdenarTickets(List<Ticket> tickets)
        {
            for (int i = 0; i < tickets.Count; i++)
            {
                for (int j = 0; j < tickets.Count; j++)
                {
                    if (tickets[i].Turn > tickets[j].Turn)
                    {
                        Ticket temp = tickets[i];
                        tickets[i] = tickets[j];
                        tickets[j] = temp;
                    }
                }
            }

            return tickets;
        }

        internal static bool AddNewTicket(Queue<Ticket> targetQueue, Ticket ticket)
        {
            bool result = false;
            //validar que la cola corresponda con el tipo de operacion.
            if (ticket.Turn > 99)
                return result;
            if(targetQueue.Peek().RequestType == ticket.RequestType)
            {
                result = true;
            }
            return result;
        }        
    }
}