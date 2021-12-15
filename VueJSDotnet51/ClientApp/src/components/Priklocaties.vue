<template>
    <h1>Locaties Star-shl</h1>
    <h5>Vul postcode in: </h5>
    <div class="form">
        <input v-model="postcodeInput" maxlength="6" placeholder="Postcode, bijv: 1234AB" />
        <br />
        <button class="btn" @click="submitFunction">Zoek</button>
    </div>

    <br />
    <p>
        <button class="btn" @click="locateMe">Detecteer locatie</button>
    </p>

    <div v-if="errorStr">
        Sorry, but the following error
        occurred: {{errorStr}}
    </div>

    <div v-if="gettingLocation">
        <i>Bezig met het detecteren van de locatie</i>
    </div>

    <div v-if="location != null">
        Gedecteerde locatie:
        <br />
        {{detectedTown}}
        <br />
        {{detectedStreet}} {{detectedNumber}}
        <br />
        {{detectedPostal}}
        <br />
    </div>

    <div class="locationwrapper" v-for="loc in locations" v-bind:key="loc">

        <div class="loc-distance" v-if="loc.distance != null">
            {{"Afstand (in km): " + ((loc.distance/1000).toFixed(2)) }}
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
                testURL: "",
                lat: "",
                lon: "",
                inputlat: "",
                inputlon: "",
                compareCoordinatesBool: false,
                inputlatfloat: 0,
                inputlonfloat: 0,
                location: null,
                gettingLocation: false,
                errorStr: null,
                detectedTown: "",
                detectedPostal: "",
                detectedStreet: "",
                detectedNumber: ""
            }
        },
        methods: {
            GetLocations() {
                axios.get("http://localhost:5000/api/location")
                    .then((response) => {
                        this.locations = response.data;
                    })
                    .catch(function (error) {
                        console.log(error);
                        alert(error);
                    });
            },

            compare_Coordinates(c, d) {
                // If we have an input postal code to compare to every entry in the DB
                if (this.compareCoordinatesBool == true || this.location != null) {
                    // Iterates through every item in DB
                    // The i represents the index, the j represents the amount of locations we want to display
                    for (let i = 0; i < this.locations.length; i++) {
                        // Binds the lat and lon for every entry in DB to a variable
                        var DBlat = this.locations[i].lat;
                        var DBlon = this.locations[i].lon;

                        // parses the string values to 4 digit floats
                        var DBlatfloat = Number(parseFloat(DBlat)).toFixed(4);
                        var DBlonfloat = Number(parseFloat(DBlon)).toFixed(4);

                        // imports haversines module to calculate distance between input coordinates and database coordinates per entry in DB
                        const haversine = require('haversine-distance')

                        // a = coordinates from database, new coordinates each iteration
                        // b = coordinates from input, stay the same during each iteration. Depends on if the users enters postalcode manually or if the location gets detected

                        const a = { latitude: DBlatfloat, longitude: DBlonfloat };
                        const b = { latitude: c, longitude: d };

                        //submit with detected coords
                        //const b = { latitude: this.location.coords.latitude, longitude: this.location.coords.longitude }


                        // calculates the distance in meters between point a and b each iteration
                        var distanceInMeters = haversine(a, b);

                        // adds distance in meters to locations[]
                        this.locations[i]['distance'] = distanceInMeters;
                    }
                    this.locations.sort(this.compare);
                }
                else {
                    //If we don't (yet) have an input postal code to compare to every entry in the DB
                    console.log("Show all locations with no distancechecks");
                }
            },
            // compares given coordinates
            compare(a, b) {
                if (a.distance < b.distance)
                    return -1;
                if (a.distance > b.distance)
                    return 1;
                return 0;
            },

            // function if the 'submit' button has been clicked
            submitFunction() {
                if (this.postcodeInput.length == 6) {
                    console.log("Postcode: " + this.postcodeInput);
                    this.compareCoordinatesBool = true;
                    this.GetCoordinates();
                }
                else {
                    console.log("error! postcode moet 6 karakters bevatten");
                    alert("Er moet een postcode ingevuld worden. Bijvoorbeeld: 1234AB");
                }
            },

            GetCoordinates() {
                //sends a request to the openstreetmap API with in the input postal code
                this.testURL = "https://nominatim.openstreetmap.org/search.php?q=" + this.postcodeInput + "&format=jsonv2";
                axios.get(this.testURL)
                    .then((response) => {
                        this.coordinates = response.data;

                        // extracts the lat and lon from the input postal code in the API
                        var inputlat = this.coordinates[0].lat;
                        var inputlon = this.coordinates[0].lon;

                        // parses the string values to 4 digit floats
                        this.inputlatfloat = parseFloat(inputlat).toFixed(4);
                        this.inputlonfloat = parseFloat(inputlon).toFixed(4);

                        // goes to compareCoordinates to compare these coordinates with coordinates stored in the DB
                        this.compare_Coordinates(this.inputlatfloat, this.inputlonfloat);
                    })
                    .catch(function (error) {
                        console.log(error);
                        alert("Geen geldige postcode. Probeer opnieuw.");
                    });
            },

            // If a location gets detected, translate the coordinates to address information such as postal code, city etc.
            GetAddressDetailsFromCoordinates() {
                var newURL = "https://nominatim.openstreetmap.org/reverse?lat=" + this.location.coords.latitude + "&lon=" + this.location.coords.longitude + "&format=jsonv2";
                axios.get(newURL)
                    .then((response) => {
                        var addresdetails = response.data;

                        // extracts the postal code from API
                        this.detectedStreet = addresdetails.address["road"];
                        this.detectedNumber = addresdetails.address["house_number"];
                        this.detectedPostal = addresdetails.address["postcode"];
                        this.detectedTown = addresdetails.address["town"];
                        this.postcodeInput = this.detectedPostal;
                    })
                    .catch(function (error) {
                        console.log(error);
                        alert("Er ging iets fout...");
                    });
            },

            // Method to detect a location, works with geolocation
            async getLocation() {
                return new Promise((resolve, reject) => {

                    if (!("geolocation" in navigator)) {
                        reject(new Error('Geolocation is not available.'));
                    }
                    navigator.geolocation.getCurrentPosition(pos => {
                        resolve(pos);
                    }, err => {
                        reject(err);
                    });

                });
            },

            // method that works with getLocation(), parses the detected coordinated to the compare_Coordinates method. Also calls a method to find the detected location street, city, postal etc.
            async locateMe() {
                this.gettingLocation = true;
                try {
                    this.gettingLocation = false;
                    this.location = await this.getLocation();
                    this.compare_Coordinates(this.location.coords.latitude, this.location.coords.longitude);
                    this.GetAddressDetailsFromCoordinates();
                } catch (e) {
                    this.gettingLocation = false;
                    this.errorStr = e.message;
                }
            }
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

    button {
        margin: 2px;
    }

    .loc-distance {
        font-weight: bold;
        margin: 2px;
    }
</style>