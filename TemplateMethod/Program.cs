using System;

namespace TemplateMethod
{


    /// <summary>
    /// 模板方法是将父类的方法延迟到子类中实现，并且可以通过钩子去控制方法的执行
    /// 比如电脑里有很多游戏，打开游戏的时候会初始化，有的游戏需要更新，而有的则不要
    /// </summary>
    public abstract class AbstractPlayGame
    {
        /// <summary>
        /// 钩子方法，默认不更新
        /// </summary>
        /// <returns></returns>
        protected virtual bool ShouldApply()
        {
            return false;
        }
        protected abstract void Init();

        /// <summary>
        /// 可以不更新
        /// </summary>
        protected abstract void Update();

        protected abstract void Load();

        public void Run()
        {
            this.Init();
            if (this.ShouldApply())
            {
                this.Update();
            }
            this.Load();
        }
    }

    /// <summary>
    /// 这个单机游戏，不要更新
    /// </summary>
    public class PlayLol : AbstractPlayGame
    {
        protected override void Init()
        {
            Console.WriteLine("Init...");
        }

        protected override void Load()
        {
            Console.WriteLine("Load...");
        }

        protected override void Update()
        {
            Console.WriteLine("Update...");
        }
    }

    /// <summary>
    /// 比如这游戏bug比较多，天天要更新，
    /// </summary>
    public class PlayCs: AbstractPlayGame
    {

        protected override bool ShouldApply()
        {
            return true;
        }

        protected override void Init()
        {
            Console.WriteLine("Init...");
        }

        protected override void Update()
        {
            Console.WriteLine("Update 这个游戏要更新...");
        }

        protected override void Load()
        {
            Console.WriteLine("Load...");
        }

        
    }

    public class Program
    {
        static void Main(string[] args)
        {
            PlayLol playLol = new PlayLol();
            playLol.Run();

            PlayCs playCs = new PlayCs();
            playCs.Run();

            Console.ReadLine();
        }
    }
}
