<template>
    <h1>Onze locaties</h1>
    <h5>Filter op: </h5>
    <div class="form">
        <input v-model="postcodeInput" maxlength="6" placeholder="Postcode?" />
        <input v-model="radiusInput" maxlength="4" placeholder="Radius???" />
        <br />
        <button class="btn" @click="testFunction">Submit</button>
    </div>
    <div class="coordinaten" v-for="co in coordinates" v-bind:key="co">
        {{"Lat : " + co.lat}}
        <br />
        {{"Lon : " + co.lon}}
    </div>

    <div class="locationwrapper" v-for="loc in locations" v-bind:key="loc">
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
                inputlon: ""

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

            testFunction() {
                if (this.postcodeInput.length == 6) {
                    console.log("Postcode: " + this.postcodeInput);
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
                        // extracts the lat from the input postal code
                        var inputlat = JSON.stringify(response.data[0].lat);
                        // extracts the lon from the input postal code
                        var inputlon = JSON.stringify(response.data[0].lon);
                        // logs the coordinates
                        console.log("lat: " + inputlat);
                        console.log("lon: " + inputlon);


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