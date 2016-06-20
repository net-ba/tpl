using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ERNI.Training.TPL.Exercise05
{
    public class Test
    {

        [Fact]
        public void WaitFileDeletedAsync_DeleteFile_TaskEnded()
        {
            const string file = "Test04.txt";
            var path = BasePath;
            var filePath = Path.Combine(path, file);
            CreateFile(filePath);

            var implement = new Implement();
            var task = implement.WaitFileDeletedAsync(path, file);

            Assert.NotEqual(TaskStatus.RanToCompletion, task.Status);

            Task.Delay(200).ContinueWith(t => File.Delete(filePath));
            bool result = task.Wait(400);

            Assert.True(result);
        }

        private string BasePath
        {
            get
            {
                return Path.GetDirectoryName(typeof(Test).Assembly.Location);
            }
        }

        private void CreateFile(string path)
        {
            using (var writer = File.CreateText(path))
            {
                writer.WriteLine("Test");
            }
        }
    }
}
