using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Schwans_ProcesX12850SpreadsheetTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create an instance of the Parameters class with the necessary values
            Parameters myParameters = new Parameters
            {
                // Set your parameter values here
                EncompassID = "ErpID",
                EncompassSessionID = "ErpSessionID",
                EncompassDBServer = "ErpDBServer",
                Email = "YourEmail",
            };

            // Load the EDI data from a file or provide it as a string
          string docContent = "ISA*00*          *00*          *08*925485US00     *01*166298TP       *230912*1119*:*00501*850100321*0*P*>~GS*PO*925485US00*166298TP*20230912*1119*850100321*X*005010~ST*850*154752~BEG*00*SA*8780452800**20230912~CUR*BY*USD~REF*DP*00091~REF*MR*0037~REF*PD*POS REPLEN~REF*IA*166298911~REF*AN*01-166298911~FOB*PP*OR*DSD XX                      XX~ITD*08*15*1**15**30~DTM*001*20230914~DTM*010*20230914~TD5*O****SRL~N9*L1*SPECIAL INSTRUCTIONS~MTX**NO PRETICKET~MTX**============================================================~MTX**TRUCK#  01 FOR 166298911   ==============================~MTX**==============================~N1*FR*WALMART INC.~N1*SU*SCHWANS CONSUMER BRANDS~PO1*001*8*CA*3.52**IN*009101775*UP*072180634719*VN*63471***IZ*23.4OZ*******UK*00072180634719~PO4*1~SDQ*CA*UL*0078742002965*8~AMT*1*28.16~PO1*002*71*CA*3.52**IN*009101973*UP*072180634733*VN*63473***IZ*20.6OZ*******UK*00072180634733~PO4*1~SDQ*CA*UL*0078742002965*71~AMT*1*249.92~PO1*003*21*CA*3.52**IN*009104520*UP*072180634290*VN*63429***IZ*21.6OZ*******UK*00072180634290~PO4*1~SDQ*CA*UL*0078742002965*21~AMT*1*73.92~PO1*004*32*CA*3.52**IN*009107434*UP*072180634696*VN*63469***IZ*22.9OZ*******UK*00072180634696~PO4*1~SDQ*CA*UL*0078742002965*32~AMT*1*112.64~PO1*005*4*CA*2.46**IN*009184870*UP*072180668509*VN*66850***IZ*9.49OZ*******UK*00072180668509~PO4*1~SDQ*CA*UL*0078742002965*4~AMT*1*9.84~PO1*006*2*CA*4.67**IN*550380669*UP*041458105343*VN*55028***IZ*36OZ*******UK*00041458105343~PO4*1~SDQ*CA*UL*0078742002965*2~AMT*1*9.34~PO1*007*15*CA*4.67**IN*550380674*UP*041458105565*VN*55032***IZ*25.5OZ*******UK*00041458105565~PO4*1~SDQ*CA*UL*0078742002965*15~AMT*1*70.05~PO1*008*6*CA*4.67**IN*550380676*UP*041458105572*VN*55033***IZ*25OZ*******UK*00041458105572~PO4*1~SDQ*CA*UL*0078742002965*6~AMT*1*28.02~PO1*009*11*CA*4.67**IN*550380679*UP*041458105688*VN*55030***IZ*30.5OZ*******UK*00041458105688~PO4*1~SDQ*CA*UL*0078742002965*11~AMT*1*51.37~PO1*010*12*CA*2.59**IN*552427169*UP*072180637185*VN*63718***IZ*18.9OZ*******UK*00072180637185~PO4*1~SDQ*CA*UL*0078742002965*12~AMT*1*31.08~PO1*011*4*CA*2.59**IN*552427170*UP*072180637178*VN*63717***IZ*18.5OZ*******UK*00072180637178~PO4*1~SDQ*CA*UL*0078742002965*4~AMT*1*10.36~PO1*012*9*CA*3.52**IN*553352708*UP*072180638106*VN*63810***IZ*17.8OZ*******UK*00072180638106~PO4*1~SDQ*CA*UL*0078742002965*9~AMT*1*31.68~PO1*013*9*CA*2.46**IN*556292356*UP*072180626455*VN*69291***IZ*6.07OZ*******UK*00072180626455~PO4*1~SDQ*CA*UL*0078742002965*9~AMT*1*22.14~PO1*014*57*CA*2.96**IN*575157024*UP*072180733665*VN*73366***IZ*11.2OZ*******UK*00072180733665~PO4*1~SDQ*CA*UL*0078742002965*57~AMT*1*168.72~PO1*015*12*CA*2.96**IN*575157028*UP*072180733672*VN*73367***IZ*11.5OZ*******UK*00072180733672~PO4*1~SDQ*CA*UL*0078742002965*12~AMT*1*35.52~PO1*016*4*CA*4.88**IN*575562380*UP*072180677730*VN*77737***IZ*22OZ*******UK*00072180677730~PO4*1~SDQ*CA*UL*0078742002965*4~AMT*1*19.52~PO1*017*8*CA*4.88**IN*575562381*UP*072180677747*VN*77744***IZ*22OZ*******UK*00072180677747~PO4*1~SDQ*CA*UL*0078742002965*8~AMT*1*39.04~PO1*018*12*CA*3.52**IN*583459342*UP*072180566119*VN*56611***IZ*18.6OZ*******UK*00072180566119~PO4*1~SDQ*CA*UL*0078742002965*12~AMT*1*42.24~PO1*019*26*CA*2.07**IN*586094897*UP*807176712733*VN*62672***IZ*6.6OZ*******UK*00807176712733~PO4*1~SDQ*CA*UL*0078742002965*26~AMT*1*53.82~PO1*020*8*CA*4.61**IN*586094898*UP*807176711705*VN*62680***IZ*24OZ*******UK*00807176711705~PO4*1~SDQ*CA*UL*0078742002965*8~AMT*1*36.88~PO1*021*4*CA*4.61**IN*586094899*UP*807176711712*VN*62681***IZ*24OZ*******UK*00807176711712~PO4*1~SDQ*CA*UL*0078742002965*4~AMT*1*18.44~PO1*022*3*CA*4.61**IN*587693793*UP*807176713228*VN*62674*BO*NA*IZ*24OZ*******UK*00807176713228~PO4*1~SDQ*CA*UL*0078742002965*3~AMT*1*13.83~PO1*023*1*CA*4.98**IN*595764738*UP*041458550853*VN*55085*BO*NA*IZ*23.9OZ*******UK*00041458550853~PO4*1~SDQ*CA*UL*0078742002965*1~AMT*1*4.98~PO1*024*1*CA*4.98**IN*595764794*UP*041458550877*VN*55087*BO*NA*IZ*27FOZ*******UK*00041458550877~PO4*1~SDQ*CA*UL*0078742002965*1~AMT*1*4.98~PO1*025*2*CA*5.53**IN*596485947*UP*072180741516*VN*74151*BO*NA*IZ*14OZ*******UK*00072180741516~PO4*1~SDQ*CA*UL*0078742002965*2~AMT*1*11.06~CTT*25~AMT*GV*1177.55~SE*123*154752~~GE*12*850100321~IEA*1*850100321~";


            string importRes = FunctionHandler(myParameters, docContent);

            // Print or save the import result
            Console.WriteLine(importRes);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        public static string FunctionHandler(Parameters myParameters, string ediData)
        {
            // The rest of your code remains unchanged
            // 

            string[] res =  ExtractValues(ediData);
                // LambdaLogger.Log("res" + string.Join("\n", res));
            string importRes = ConvertToCsv(myParameters,res);

            // Return the import result as a string
            return importRes;
        }

        public static string[] ExtractValues(string ediData)
        {
            //string[] segments = ediData.Split(new string[] { "~\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            string[] segments = ediData.Split(new string[] { "~" }, StringSplitOptions.RemoveEmptyEntries);
           
            List<string> result = new List<string>();



            // headers
            string senderID =  ExtractHeaderValue(segments, "ISA", "06"); //  senderID
            string receiverID =  ExtractHeaderValue(segments, "ISA", "08"); //  receiverID
            string iSAdocNum = ExtractHeaderValue(segments, "ISA", "13"); //  ISAdocNum
            string production = ExtractHeaderValue(segments, "ISA", "15"); //  production
            string functionalType = ExtractHeaderValue(segments, "ST", "01"); //  functionalType
            string functionalIDCode = ExtractHeaderValue(segments, "GS", "01");  //  functionalIDCode
            string controlNumber = ExtractHeaderValue(segments, "GS", "06"); //  controlNumber
            string time =  ExtractHeaderValue(segments, "GS", "05"); // Initialize time

            if (int.TryParse(time, out int timeValue))
            {
                int hour = timeValue / 100;
                int minute = timeValue % 100;

                if (hour >= 0 && hour < 24 && minute >= 0 && minute < 60)
                {
                    string formattedTime = $"{hour:D2}:{minute:D2}:00";
                    time = formattedTime;
                }
                else
                {
                    time = "Invalid time format.";
                }
            }
            else
            {
                time = "Invalid time format.";
            }



            string poDate = ""; // Initialize PO Date
            string unitOfMeasure= ""; // Initialize unitOfMeasure
            string carrierUPC = ""; // Initialize carrierUPC
            string poNum = ""; //  poNum
            string pOReceivedDate = ""; // PO Received Date
            string traceNum =  ""; //  Trance number

          

          
           // Initialize variables to keep track of transaction boundaries
        int transactionStartIndex = -1;
        int transactionEndIndex = -1;

            for (int i = 0; i < segments.Length; i++)
            {
                 string[] fields = segments[i].Split('*');
              
                
            
                    if (fields.Length > 0 && fields[0] == "ST")
                    {
                        // Found the start of a transaction

                        
                        transactionStartIndex = i;
                        int elementIndex = 2; // The index for the TraceNum
                        if (fields.Length > elementIndex)
                        {
                            traceNum = fields[elementIndex];
                        }
                    }
                    else if (fields.Length > 0 && fields[0] == "SE")
                    {   
                         
                        // Found the end of a transaction
                        transactionEndIndex = i;

                        // Process the transaction from start to end
                        if (transactionStartIndex >= 0 && transactionEndIndex >= 0)
                        {
                            string[] stParts = segments[transactionStartIndex].Split('*');
                            string[] seParts = segments[transactionEndIndex].Split('*');
                             
                             
                            if (stParts.Length > 2 && seParts.Length > 2 && stParts[2] == seParts[2])
                            {
                                for (int j = transactionStartIndex + 1; j < transactionEndIndex; j++)
                                {
                                    string[] transactionFields = segments[j].Split('*');

                                    if (transactionFields.Length > 0)
                                    {
                                        string fieldIdentifier = transactionFields[0];
                                           // Extract data based on the field identifier
                                            if (fieldIdentifier == "PO1")
                                            {
                                                // Extract PO1 segment data
                                                int elementIndex = 3; // The index for the unit of measure
                                                if (transactionFields.Length > elementIndex)
                                                {
                                                    unitOfMeasure = transactionFields[elementIndex];
                                                }

                                                int elementIndex2 = 9; // The index for the carrier UPC
                                                if (transactionFields.Length > elementIndex2)
                                                {
                                                    carrierUPC = transactionFields[elementIndex2];
                                                }
                                            }
                                            else if (fieldIdentifier == "DTM")
                                            {
                                                // Extract DTM segment data
                                                for (int elementIndex = 1; elementIndex < transactionFields.Length - 1; elementIndex += 2)
                                                {
                                                    if (transactionFields[elementIndex] == "002")
                                                    {
                                                        poDate = transactionFields[elementIndex + 1];
                                                        DateTime deliveryDate = DateTime.ParseExact(poDate, "yyyyMMdd", null);
                                                        poDate = deliveryDate.ToString("yyyy-MM-dd");
                                                        break; // This will exit the loop after finding "002"
                                                    }
                                                    else if (transactionFields[elementIndex] == "010")
                                                    {
                                                        poDate = transactionFields[elementIndex + 1];
                                                        DateTime deliveryDate = DateTime.ParseExact(poDate, "yyyyMMdd", null);
                                                        poDate = deliveryDate.ToString("yyyy-MM-dd");
                                                    }
                                                }
                                            }
                                            else if (fieldIdentifier == "BEG")
                                            {
                                                // Extract BEG segment data
                                                int elementIndex = 3; // The index for the PONUM
                                                if (transactionFields.Length > elementIndex)
                                                {
                                                    poNum = transactionFields[elementIndex];
                                                }

                                                // Extract PO Received Date
                                                elementIndex = 5; // The index for PO Received Date
                                                if (transactionFields.Length > elementIndex)
                                                {
                                                    pOReceivedDate = transactionFields[elementIndex];
                                                    DateTime receiveDate = DateTime.ParseExact(pOReceivedDate, "yyyyMMdd", null);
                                                    pOReceivedDate = receiveDate.ToString("yyyy-MM-dd");
                                                }
                                            }
                                              else if (fieldIdentifier == "SDQ")
                                            {
                                                // Extract SDQ segment data
                                                for (int k = 0; k < transactionFields.Length - 1; k++)
                                                {
                                                    if (!string.IsNullOrEmpty(transactionFields[k]) && transactionFields[k].StartsWith("00"))
                                                    {
                                                        string chainStoreNum = transactionFields[k];
                                                        string numUnits = transactionFields[k + 1];
                                                        string combinedResult = $"ITEM,{iSAdocNum},{functionalType},{traceNum},{poNum},{poDate},{pOReceivedDate},{senderID},{receiverID.Replace(" ", "")},{time},FALSE,{production},{functionalIDCode},{controlNumber},{unitOfMeasure},{carrierUPC},{chainStoreNum},{numUnits}";
                                                        
                                                        result.Add(combinedResult);
                                                    }
                                                }
                                            }

                                    }
                                }

                                // Reset transaction boundaries
                                transactionStartIndex = -1;
                                transactionEndIndex = -1;
                            }
                            else
                            {
                                Console.WriteLine($"ST and SE segments do not match for transaction {stParts[2]}");
                            }
                        }
                    }
            }
            return result.ToArray();
        }


        static string ExtractHeaderValue(string[] segments, string segmentId, string elementId)
        {
            // string[] segments = content.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < segments.Length; i++)
            {
                string[] elements = segments[i].Split('*');

                // Find the segment with the specified segmentId
                if (elements.Length > 0 && elements[0] == segmentId)
                {
                    // Extract the specified element if available
                    int elementIndex = Convert.ToInt32(elementId);
                    if (elements.Length > elementIndex)
                    {
                        return elements[elementIndex];
                    }
                    else
                    {
                        return null; // Specified element not found
                    }
                }
            }

            return null; // Segment not found
        }


       public static string ConvertToCsv(Parameters myParameters, string[] res)
    {
        StringBuilder resultBuilder = new StringBuilder();

        var groupedByColumn4 = res.GroupBy(line =>
        {
            var columns = line.Split(',');
            if (columns.Length > 4)
            {
                return columns[4];
            }
            return "N/A"; // You can use a default value if columns[4] is not available
        }).ToArray(); // Convert to array to use numeric indices

        for (int i = 0; i < groupedByColumn4.Length; i++)
        {
            // Separate groups by "HEADER,,,850"
            // resultBuilder.AppendLine("HEADER,,,850");

            var groupedByColumn16 = groupedByColumn4[i].GroupBy(line =>
            {
                var columns = line.Split(',');
                if (columns.Length > 16 && double.TryParse(columns[16], out double value))
                {
                    return value;
                }
                return double.MaxValue;
            }).ToArray(); // Convert to array to use numeric indices

            for (int j = 0; j < groupedByColumn16.Length; j++)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (StreamWriter streamWriter = new StreamWriter(memoryStream, Encoding.UTF8))
                    {
                        streamWriter.WriteLine("HEADER,,,850");
                        foreach (var line in groupedByColumn16[j])
                        {
                            streamWriter.WriteLine(line);
                        }
                        streamWriter.Flush();

                        // Get the CSV data from the MemoryStream
                        byte[] csvData = memoryStream.ToArray();
                        MemoryStream ms = new MemoryStream(csvData);
                         Program programInstance = new Program();
                         programInstance.SendHttpPostRequest(ms);
                  
                    }
                }
            }
        }

        return resultBuilder.ToString();
    }

    private void SendHttpPostRequest(MemoryStream csvMemoryStream)
    {
        string apiUrl = "https://webhook.site/8a6901d6-3843-486c-b9b4-c34af2c9f6a1";

        using (HttpClient client = new HttpClient())
        {
            // Convert the MemoryStream to a string (CSV data)
            string csvContent = Encoding.ASCII.GetString(csvMemoryStream.ToArray());

            // Create content for the HTTP POST request
            var content = new StringContent(csvContent, Encoding.UTF8, "text/csv");

            // Send the HTTP POST request to the specified URL
            HttpResponseMessage response = client.PostAsync(apiUrl, content).Result;

            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                string responseContent = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("HTTP POST request was successful.");
                Console.WriteLine("Response content: " + responseContent);
            }
            else
            {
                Console.WriteLine("HTTP POST request failed with status code: " + response.StatusCode);
            }
        }
    }

}



        // Define the Parameters class here
        public class Parameters
        {
            public string EncompassID { get; set; }
            public string EncompassSessionID { get; set; }
            public string EncompassDBServer { get; set; }
            public string Email { get; set; }
        }
    
}
