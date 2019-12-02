using OpenQA.Selenium.Chrome;

namespace POC.Selenium.Job
{
    public static class Job
    {
        public static string Execute()
        {
            //var basePath = System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("POC.Selenium"));
            //string driverPath = $"{basePath}POC.Selenium\\src\\POC.Selenium.Job\\WebDrivers";

            string driverPath = $"/app/assets/WebDrivers";

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            chromeOptions.AddArguments("--no-sandbox");
            chromeOptions.AddArguments("--disable-dev-shm-usage");

            using (var browser = new ChromeDriver(driverPath, chromeOptions))
            {
                // add your code here
            }


            return "Job 2";
        }
    }
}
