using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bioplugin.Cloudscanr.Csharp.Web.Sample.Utilities
{
    public static class ResponseHelper
    {
        public enum BPOperationName
        {
            None = 0,
            Register = 1,
            Identify = 2,
            Verify = 3,
            Update = 4,
            IsRegister = 5,
            DeleteID = 6,
            ChangeID = 7
        }
        public static string ProcessServerResult(string result, BPOperationName operationName)
        {
            string serverResult = string.Empty;

            switch (result)
            {

                case "SUCCESS":
                    serverResult = string.Format("{0} successfull.", operationName.ToString());
                    break;
                case "LICENSE_ERROR":
                    serverResult = "License related problem orccured.";
                    break;
                case "11":
                    serverResult = "Duplicate found.";
                    break;
                case "27":
                    serverResult = "Duplicate found.";
                    break;
                case "16":
                    serverResult = "Duplicate found.";
                    break;
                case "38":
                    serverResult = "Duplicate found.";
                    break;
                case "INVALID_ENGINE":
                    serverResult = "Requested engine is invalid.";
                    break;
                case "-1":
                    if (operationName == BPOperationName.Register)
                        serverResult = "Registration ID exist in the system";
                    else if (operationName == BPOperationName.Identify)
                        serverResult = "Your Biometric is not in the system.";
                    //else if (operationName == BPOperationName.IsRegister)
                    //    serverResult = "Duplicate not found";
                    else if (operationName == BPOperationName.Verify)
                        serverResult = "Verify Id not found in the system";
                    else if (operationName == BPOperationName.DeleteID
                        || operationName == BPOperationName.ChangeID
                        || operationName == BPOperationName.IsRegister
                        || operationName == BPOperationName.Update)
                        serverResult = "Registration Id not exist in the system";
                    else
                        serverResult = "Biometric operation failed.";
                    break;
                case "0":
                    if (operationName == BPOperationName.DeleteID)
                        serverResult = "Delete was completed successfully.";
                    else if (operationName == BPOperationName.Verify)
                        serverResult = "Verify was completed successfully.";
                    else if (operationName == BPOperationName.ChangeID)
                        serverResult = "Change was completed successfully.";
                    else
                        serverResult = "Biometric operation failed.";
                    break;
                case "":
                    serverResult = "Web service connection failed.";
                    break;
                case "-411":
                    serverResult = "Bioplugin server connection timeout. Please try again.";
                    break;
                default:
                    serverResult = "Biometric record found in the system with ID - " + result;
                    break;
            }

            return serverResult;
        }
    }
}