using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCCGBreeze.Models;
using GoogleMapsCoreApi;
using GoogleMapsCoreApi.Entities.Common;
using GoogleMapsCoreApi.Entities.Directions.Request;
using GoogleMapsCoreApi.Entities.Directions.Response;
using GoogleMapsCoreApi.Entities.DistanceMatrix.Request;
using GoogleMapsCoreApi.Entities.DistanceMatrix.Response;
using GoogleMapsCoreApi.Entities.Elevation.Request;
using GoogleMapsCoreApi.Entities.Geocoding.Request;
using GoogleMapsCoreApi.Entities.Geocoding.Response;
using GoogleMapsCoreApi.StaticMaps;
using GoogleMapsCoreApi.StaticMaps.Entities;
using Newtonsoft.Json;

namespace CCCGBreeze.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private static cccgcontext _context;
        public AddressesController(cccgcontext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("notesload")]
        public void NotesLoad()
        {
            List<string> ids = new List<string>();

            var client = new RestClient("https://cccg.breezechms.com/api/people");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("api-key", "842079415fd81bbfbedbb048cd1db471");
            var body = @"";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            JArray array = JArray.Parse(response.Content);

            try
            {
                foreach (var token in array)
                {
                    string id = token["id"].ToString();
                    ids.Add(id);
                    client.BaseUrl = new Uri("https://cccg.breezechms.com/api/people/" + id);
                    response = client.Execute(request);
                    JObject jObject = JObject.Parse(response.Content);

                    addresses current = new addresses
                    {
                        id = id,
                        firstname = jObject["first_name"].ToString(),
                        lastname = jObject["last_name"].ToString(),
                        address = jObject["street_address"].ToString() + " " + jObject["city"].ToString() + " " + jObject["state"].ToString() + " " + jObject["zip"].ToString(),
                        phone = "",
                        email = ""
                    };

                    if (jObject["details"]["373735825"] != null)
                    {
                        current.phone = jObject["details"]["373735825"][0]["address"].ToString();

                        if (jObject["details"]["373735825"].Children().Count() > 1)
                        {
                            if (jObject["details"]["373735825"][1]["address"].ToString() != "")
                                current.email = jObject["details"]["373735825"][1]["address"].ToString();
                        }

                    }

                    if (jObject["details"]["53821426"] != null)
                    {
                        current.phone = jObject["details"]["53821426"][0]["phone_number"].ToString();

                        if (jObject["details"]["53821426"].Children().Count() > 1)
                        {
                            if (jObject["details"]["53821426"][1]["phone_number"].ToString() != "")
                                current.phone = jObject["details"]["53821426"][1]["phone_number"].ToString();
                        }

                    }




                }


            }
            catch (Exception ioe)
            {
                Console.WriteLine(ioe.Message);
            }

        }

        [HttpGet]
        public void Load()
        {
            List<addresses> addresses = new List<addresses>();
            List<string> ids = new List<string>();

            var client = new RestClient("https://cccg.breezechms.com/api/people/?filter_json={\"tag_contains\":\"y_2178692\"}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("api-key", "842079415fd81bbfbedbb048cd1db471");
            var body = @"";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            JArray array = JArray.Parse(response.Content);

            try
            {
                foreach (var token in array)
                {
                    string id = token["id"].ToString();
                    ids.Add(id);
                    client.BaseUrl = new Uri("https://cccg.breezechms.com/api/people/" + id);
                    response = client.Execute(request);
                    JObject jObject = JObject.Parse(response.Content);

                    addresses current = new addresses
                    {
                        id = id,
                        firstname = jObject["first_name"].ToString(),
                        lastname = jObject["last_name"].ToString(),
                        address = jObject["street_address"].ToString() + " " + jObject["city"].ToString() + " " + jObject["state"].ToString() + " " + jObject["zip"].ToString(),
                        phone = "",
                        email = ""
                    };

                    if (jObject["details"]["373735825"] != null)
                    {
                        current.phone = jObject["details"]["373735825"][0]["address"].ToString();

                        if (jObject["details"]["373735825"].Children().Count() > 1)
                        {
                            if (jObject["details"]["373735825"][1]["address"].ToString() != "")
                                current.email = jObject["details"]["373735825"][1]["address"].ToString();
                        }

                    }

                    if (jObject["details"]["53821426"] != null)
                    {
                        current.phone = jObject["details"]["53821426"][0]["phone_number"].ToString();

                        if (jObject["details"]["53821426"].Children().Count() > 1)
                        {
                            if (jObject["details"]["53821426"][1]["phone_number"].ToString() != "")
                                current.phone = jObject["details"]["53821426"][1]["phone_number"].ToString();
                        }

                    }

                    addresses.Add(current);
                    _context.addresses.Add(current);
                    _context.SaveChangesAsync();




                }

               
            }
            catch(Exception ioe)
            {
                Console.WriteLine(ioe.Message);
            }

        }

        [HttpGet]
        [Route("lifeload")]
        public void LifeGroupLoad()
        {
            List<lifegroups> lifegroups = new List<lifegroups>();
            List<string> ids = new List<string>();

            var client = new RestClient("https://cccg.breezechms.com/api/people/?filter_json={\"tag_contains\":\"y_3884358-y_3884360-y_3884356-y_4483430-y_3938644-y_3938642-y_4602262-y_2178692-y_2178774-y_2178744-y_2887920-y_2178754-y_2178758-y_2178756-y_2178760-y_4201040-y_2178766-y_2178768-y_3544182-y_2178746-y_2178646-y_2178770-y_2978338-y_4201672-y_2178772-y_2178736-y_2178764-y_3305082-y_3938648-y_2178750-y_2178644-y_4201044-y_3884366-y_3884368-y_3884352-y_3884354-y_3884350-y_1719478-y_3132896-y_3132894-y_1719482-y_3132900-y_1719479\"}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("api-key", "842079415fd81bbfbedbb048cd1db471");
            var body = @"";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            JArray array = JArray.Parse(response.Content);

            try
            {
                foreach (var token in array)
                {
                    string id = token["id"].ToString();
                    ids.Add(id);
                    client.BaseUrl = new Uri("https://cccg.breezechms.com/api/people/" + id);
                    response = client.Execute(request);
                    JObject jObject = JObject.Parse(response.Content);
                    DateTime dt = new DateTime();

                    if (jObject["details"]["birthdate"] != null && DateTime.TryParse(jObject["details"]["birthdate"].ToString(), out dt))
                    {
                        dt = (DateTime)(jObject["details"]["birthdate"]);
                    }
                    else
                    {
                        dt = DateTime.Now;
                    }

                    var street = jObject["street_address"] == null ? "" : jObject["street_address"].ToString();

                    var city = jObject["city"] == null ? "" : jObject["city"].ToString();

                    var state = jObject["state"] == null ? "" : jObject["state"].ToString();

                    var zip = jObject["zip"] == null ? "" : jObject["zip"].ToString();


                    lifegroups current = new lifegroups
                    {
                        id = id,
                        firstname = jObject["first_name"] == null ? "" : jObject["first_name"].ToString(),
                        lastname = jObject["last_name"] == null ? "" : jObject["last_name"].ToString(),
                        address = street + " " + city + " " + state + " " + zip,
                        phone = "",
                        email = jObject["details"]["373735825"] == null ? "" : jObject["details"]["373735825"][0]["address"].ToString(),
                        age = jObject["details"]["birthdate"] == null ? 0 : DateTime.Now.Subtract(dt).Days/365,
                        gender = jObject["details"]["1677821181"] == null ? "" : jObject["details"]["1677821181"]["name"].ToString(),
                        status = jObject["details"]["2140604756"] == null ? "" : jObject["details"]["2140604756"]["name"].ToString(),
                        profession = ""
                    };


                    if (jObject["details"]["53821426"] != null)
                    {
                        current.phone = jObject["details"]["53821426"][0] == null ?  "" : jObject["details"]["53821426"][0]["phone_number"].ToString();

                        if (jObject["details"]["53821426"].Children().Count() > 1)
                        {
                            if (jObject["details"]["53821426"][1]["phone_number"].ToString() != "")
                                current.phone = jObject["details"]["53821426"][1]["phone_number"].ToString();
                        }

                    }

                    lifegroups.Add(current);
                    _context.lifegroups.Add(current);
                   

                }

                _context.SaveChangesAsync();



            }
            catch (Exception ioe)
            {
                Console.WriteLine(ioe.Message);
            }

        }


        [HttpGet]
        [Route("closestTo")]
        public string Get()
        {
            var needsARide = Request.Query["dest"].ToString();
            var addressList = _context.addresses.ToList();
            List<AddressTracker> sortedList = new List<AddressTracker>();

            string[][] checkDist = new string[addressList.Count()][];

            foreach(var item in addressList)
            {
                var drivingDirection = new DistanceMatrixRequest
                {
                    ApiKey = "AIzaSyCpA7y-2Al3NIAJuH8jQKFFmk2U55QOG7w",
                    Destinations = new[] { needsARide },
                    Origins = new[] { item.address },
                    Mode = DistanceMatrixTravelModes.driving
                };

                var result = GoogleMaps.DistanceMatrix.Query(drivingDirection);

                AddressTracker current = new AddressTracker
                {
                    addresses1 = item,
                    duration = GetDuration(result)
                };

                sortedList.Add(current);
            }

            var sortedList2 = sortedList.OrderBy(x => x.duration);
            string finalList = "";

            foreach(var add in sortedList2)
            {
                if(add.addresses1.address.Trim() != "" && add.addresses1.address != null)
                {
                    finalList += add.addresses1.firstname + " " + add.addresses1.lastname
                     + "\nContact: " + add.addresses1.phone + " " + add.addresses1.email
                     + "\n" + add.addresses1.address + "\n" + add.duration.ToString() + "\n\n";
                }  
           
            }
            //var value = new
            //{
            //    submissions = finalList
            //};
            //var settings = new JsonSerializerSettings()
            //{
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            //    Error = (sender, args) =>
            //    {
            //        args.ErrorContext.Handled = true;
            //    },
            //};
            //return JsonConvert.SerializeObject(value, settings);

            return finalList;

        }

        private static TimeSpan? GetDuration(DistanceMatrixResponse result)
        {
                var row = result.Rows.FirstOrDefault();

                var element = row?.Elements.FirstOrDefault();

                var duration = element?.Duration;

                return duration?.Value;
            
        }
    }

    public class AddressTracker
    {
        public addresses addresses1 { get; set; }
        public TimeSpan? duration { get; set; }

    }
 
}
