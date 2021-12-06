<template>
    <h1>Onze locaties</h1>
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
                id: 0,
                city: "",
                name: "",
                street: "",
                postcode: "",
                openinghours: "",
                particularities: ""

            }
        },
        methods: {
            GetLocations() {
                axios.get("http://localhost:50598/api/location")
                    .then((response) => {
                        this.locations = response.data;
                    })
                    .catch(function (error) {
                        console.log(error);
                        alert(error);
                    });
            }
        },
        mounted() {
            this.GetLocations();
        }
    }
</script>

<style scoped>
    .locationwrapper{
        margin: 0.8rem;
        padding: 0.4rem;
        background-color: #fafafa;
        border: 1px solid #555;
        border-radius: 1rem;
        box-shadow: 0 1px 3px rgba(0,0,0,0.12), 0 1px 2px rgba(0,0,0,0.24); transition: all 0.3s cubic-bezier(.25,.8,.25,1);
    }
</style>