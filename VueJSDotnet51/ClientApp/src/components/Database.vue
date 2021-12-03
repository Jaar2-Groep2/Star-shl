<template>
    <h1 id="tableLabel">Database test</h1>

    <p>This component demonstrates fetching data from the server.</p>

    <p v-if="!databases"><em>Loading...</em></p>

    <table class='table table-striped' aria-labelledby="tableLabel" v-if="databases">
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
            <tr v-for="database of databases" v-bind:key="database">
                <td>{{ databases.city }}</td>
                <td>{{ databases.locname }}</td>
                <td>{{ databases.address }}</td>
                <td>{{ databases.postalCode }}</td>
                <td>{{ databases.openTimes }}</td>
                <td>{{ databases.additional }}</td>
            </tr>
        </tbody>
    </table>
</template>


<script>
    import axios from 'axios'
    export default {
        name: "Database",
        data() {
            return {
                databases: []
            }
        },
        methods: {
            GetLocations() {
                axios.get("http://localhost:8080")
                    .then((response) => {
                        this.databases = response.data;
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