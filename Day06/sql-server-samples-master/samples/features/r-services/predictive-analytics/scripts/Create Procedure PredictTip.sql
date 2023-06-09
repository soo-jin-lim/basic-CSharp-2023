USE [taxidata]
GO

CREATE PROCEDURE [dbo].[PredictTip]
	@passenger_count int = 0,
	@trip_distance float = 0,
	@trip_time_in_secs int = 0,
	@direct_distance float = 0
AS
BEGIN

  -- Package the inputs as a table	
  DECLARE @inquery nvarchar(max) = N'
	SELECT * FROM [dbo].[fnEngineerFeatures](
		@passenger_count,
		@trip_distance,
		@trip_time_in_secs,
		@direct_distance)
	'

  -- Load the serialized model from the nyc_taxi_models table		
  DECLARE @lmodel2 varbinary(max) = (SELECT TOP 1 model FROM nyc_taxi_models);

  -- Invoke the prediction
  EXEC sp_execute_external_script
		@language = N'R',
        @script = N'
			mod <- unserialize(as.raw(model));

			OutputDataSet <-rxPredict(modelObject = mod, data = InputDataSet, outData = NULL,
						predVarNames = "Score", type = "response", writeModelVars = FALSE, overwrite = TRUE);
			',
		@input_data_1 = @inquery,
		@params = N'@model varbinary(max),
					@passenger_count int,
					@trip_distance float,
					@trip_time_in_secs int ,
					@direct_distance float',
        @model = @lmodel2,
		@passenger_count = @passenger_count ,
		@trip_distance = @trip_distance,
		@trip_time_in_secs = @trip_time_in_secs,
		@direct_distance = @direct_distance
		WITH RESULT SETS ((Score float));

END


