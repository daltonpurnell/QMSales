using System;
using Xamarin.Forms;
using Amazon.CognitoIdentity;
using Amazon;
using Amazon.S3;

namespace QMSales
{
	public class App : Application
	{

		public App ()
		{

			MainPage = (new FirstPage());


		}

		protected override void OnStart ()
		{

//			// Initialize the Amazon Cognito credentials provider
//			CognitoAWSCredentials credentials = new CognitoAWSCredentials (
//				"us-east-1:a00a5234-5f0f-41f4-b9a0-cb72480f502a", // Identity Pool ID
//				RegionEndpoint.USEast1 // Region
//			);
//
//			// configure logging for aws
//			var loggingConfig = AWSConfigs.LoggingConfig;
//			loggingConfig.LogMetrics = true;
//			loggingConfig.LogResponses = ResponseLoggingOption.Always;
//			loggingConfig.LogMetricsFormat = LogMetricsFormatOption.JSON;
//			loggingConfig.LogTo = LoggingOptions.SystemDiagnostics;
//
//			// set region endpoint
//			AWSConfigs.AWSRegion="us-east-1";
//			IAmazonS3 s3Client = new AmazonS3Client(credentials,RegionEndpoint.USEast1);
//
//			// configure clock skew
//			AWSConfigs.CorrectForClockSkew = true;
//			var offset = AWSConfigs.ClockOffset;
//
//
//			AWSConfigsS3.UseSignatureVersion4 = true;



		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

