using MySuperBank2Library;

namespace MySuperBank2Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }

        [Fact]
        public void Test2()
        {
            var acc=new BankAccount("Gauri", 1000);
            Assert.Throws<InvalidOperationException>(
                ()=> acc.MakeWithdrawal(2000, DateTime.Now, "Watch")
                );
        }

        [Fact]
        public void Test3()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                ()=>new BankAccount("Gauri", -90)
                );
        }
    }
}