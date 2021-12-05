<template>
    <h1 id="tableLabel">Database test</h1>

    <p>This component demonstrates fetching data from the server.</p>

    <p v-if="!locations"><em>Loading...</em></p>

    <table class='table table-striped' aria-labelledby="tableLabel" v-if="locations">
        <thead>
            <tr>
                <th>City</th>
                <th>Location Name</th>
                <th>Address</th>
                <th>Postal Code</th>
                <th>Open</th>
                <th>Additional</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="loc in locations" v-bind:key="loc" >
                <td>{{ loc.city }}</td>
                <td>{{ loc.name }}</td>
                <td>{{ loc.street }}</td>
                <td>{{ loc.postcode }}</td>
                <td>{{ loc.openinghours }}</td>
                <td>{{ loc.particularities }}</td>
            </tr>
        </tbody>
    </table>
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
                //"https://jsonplaceholder.typicode.com/todos/1" for testing purposes
                // <th>API TEST</th>
                // <td>{{databases.id}}</td>
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