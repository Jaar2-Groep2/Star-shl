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
                <td>{{ database.city }}</td>
                <td>{{ database.locname }}</td>
                <td>{{ database.address }}</td>
                <td>{{ database.postalCode }}</td>
                <td>{{ database.openTimes }}</td>
                <td>{{ database.additional }}</td>
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
            getDatabases() {
                axios.get('/Database')
                    .then((response) => {
                        this.databases = response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            }
        },
        mounted() {
            this.getDatabases();
        }
    }
</script>