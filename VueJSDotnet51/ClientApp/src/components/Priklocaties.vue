<template>
    <h1>Onze locaties</h1>
    <h5>Filter op: </h5>
    <div class="form">
        <input v-model="postcodeInput" maxlength="6" placeholder="Postcode?" />
        <input v-model="radiusInput" maxlength="4" placeholder="Radius???" />
        <br />
        <button class="btn" @click="testFunction">Submit</button>
    </div>

    <div class="locationwrapper" v-for="loc in locations" v-bind:key="loc">

        <div class="ewaja" v-if="loc.distance != null">
            {{"KM: " + ((loc.distance/1000).toFixed(2)) }}
        </div>
        <div class="loc-city">
            {{ "Plaats: " + loc.city }}
        </div>
        <div class="loc-name">
            {{ "Locatie: " + loc.name }}
        </div>
        <div class="loc-street">
            {{ "Adres: " + loc.street }}
        </div>
        <div class="loc-postcode">
            {{ "Postcode: " + loc.postcode }}
        </div>
        <div class="loc-openinghours">
            {{ "Openingstijden: " + loc.openinghours }}
        </div>
        <div class="loc-particularities">
            {{ "Bijzonderheden: " + loc.particularities }}
        </div>
    </div>
</template>

<script>
    import axios from 'axios'
    export default {
        name: "locations",
        data() {
            return {
                locations: [],
                coordinates: [],
                coordinatesJson: [],
                id: 0,
                city: "",
                name: "",
                street: "",
                postcode: "",
                openinghours: "",
                particularities: "",
                postcodeInput: "",
                radiusInput: "",
                testURL: "",
                lat: "",
                lon: "",
                inputlat: "",
                inputlon: "",
                compareCoordinates: false,
                inputlatfloat: 0,
                inputlonfloat: 0

            }
        },
        methods: {
            GetLocations() {
                axios.get("http://localhost:5000/api/location")
                    .then((response) => {
                        this.locations = response.data;
                        // If we have an input postal code to compare to every entry in the DB
                        if (this.compareCoordinates == true)
                        {
                            // Iterates through every item in DB
                            // The i represents the index, the j represents the amount of locations we want to display
                            for (let i = 0; i < this.locations.length; i++)
                            {
                                // Binds the lat and lon for every entry in DB to a variable
                                var DBlat = this.locations[i].lat;
                                var DBlon = this.locations[i].lon;

                                // parses the string values to 4 digit floats
                                var DBlatfloat = Number(parseFloat(DBlat)).toFixed(4);
                                var DBlonfloat = Number(parseFloat(DBlon)).toFixed(4);

                                // imports haversines module to calculate distance between input coordinates and database coordinates per entry in DB
                                const haversine = require('haversine-distance')

                                // a = coordinates from database, new coordinates each iteration
                                // b = coordinates from input, stay the same during each iteration
                                const a = { latitude: DBlatfloat, longitude: DBlonfloat };
                                const b = { latitude: this.inputlatfloat, longitude: this.inputlonfloat };


                                // calculates the distance in meters between point a and b each iteration
                                var distanceInMeters = haversine(a, b);
                                var distanceInKM = (distanceInMeters / 1000).toFixed(2);

                                this.locations[i]['distance'] = distanceInMeters;
                                
                      
                            }

                            // nog mee bezig 
                            this.locations.sort(this.compare);

                            for (let j = 0; j < this.locations.length; j++)
                            {
                                console.log(this.locations[j].distance);
                                console.log(this.locations[j].city);
                                console.log(this.locations[j].name);
                                console.log(this.locations[j].street);
                                console.log(this.locations[j].postcode);
                                console.log(this.locations[j].openinghours);
                                console.log(this.locations[j].particularities);
                                console.log("_____________________")
                            }
                            
                        }
                                
                        
                        else {
                            //If we don't (yet) have an input postal code to compare to every entry in the DB
                            console.log("Show all locations");
                        }
                    })
                    .catch(function (error) {
                        console.log(error);
                        alert(error);
                    });
            },
            compare(a, b) {
                if (a.distance < b.distance)
                    return -1;
                if (a.distance > b.distance)
                    return 1;
                return 0;
            },


            testFunction() {
                if (this.postcodeInput.length == 6) {
                    console.log("Postcode: " + this.postcodeInput);
                    this.compareCoordinates = true;
                    this.GetCoordinates();
                }
                else
                {
                    console.log("error! postcode moet 6 karakters bevatten");
                }
                if (this.radiusInput >= 1) {
                    console.log("Radius in km: " + this.radiusInput);
                }
                else
                {
                    console.log("error! radius moet minimaal 1 karakter bevatten");
                }  
            },

            GetCoordinates()
            {
                //sends a request to the openstreetmap API with in the input postal code
                this.testURL = "https://nominatim.openstreetmap.org/search.php?q=" + this.postcodeInput + "&format=jsonv2";
                axios.get(this.testURL)
                    .then((response) => {
                        this.coordinates = response.data;

                        // extracts the lat and lon from the input postal code
                        var inputlat = this.coordinates[0].lat;
                        var inputlon = this.coordinates[0].lon;

                        // parses the string values to 4 digit floats
                        this.inputlatfloat = parseFloat(inputlat).toFixed(4);
                        this.inputlonfloat = parseFloat(inputlon).toFixed(4);

                        // goes to GetLocations to compare these coordinates with coordinates stored in the DB
                        this.GetLocations()
                    })
                    .catch(function (error) {
                        console.log(error);
                        alert(error);
                    });
            },
        }, 

        mounted() {
            this.GetLocations();
        }
    }
</script>

<style scoped>
    .locationwrapper {
        margin: 0.8rem;
        padding: 0.4rem;
        background-color: #fafafa;
        border: 1px solid #555;
        border-radius: 1rem;
        box-shadow: 0 1px 3px rgba(0,0,0,0.12), 0 1px 2px rgba(0,0,0,0.24);
        transition: all 0.3s cubic-bezier(.25,.8,.25,1);
    }
    input, select, optgroup, textarea {
        margin: 0;
        font-family: inherit;
        font-size: inherit;
        line-height: inherit;
        background-color: transparent;
    }
    button{
        margin: 0;
    }
</style>