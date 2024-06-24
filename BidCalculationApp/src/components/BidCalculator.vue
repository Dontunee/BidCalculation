<template>
  <div id="app">
    <form @submit.prevent="handleSubmit">
      <div>
        <label for="amount">Amount:</label>
        <input type="number" id="amount" v-model="form.basePrice" required />
      </div>
      <div>
        <label for="type">Type:</label>
        <select id="type" v-model="form.vehicleType" required>
          <option value="basic">Basic</option>
          <option value="common">Common</option>
        </select>
      </div>
      <button type="submit">Submit</button>
    </form>
    <div v-if="submitted">
      <h3>API Response:</h3>
      <table v-if="apiResponse">
        <thead>
          <tr>
            <th>Association Fee</th>
            <th>Base Price</th>
            <th>Basic Fee</th>
            <th>Special Fee</th>
            <th>Storage Fee</th>
            <th>Total Price</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>{{ apiResponse.associationFee }}</td>
            <td>{{ apiResponse.basePrice }}</td>
            <td>{{ apiResponse.basicFee }}</td>
            <td>{{ apiResponse.specialFee }}</td>
            <td>{{ apiResponse.storageFee }}</td>
            <td>{{ apiResponse.totalPrice }}</td>
          </tr>
        </tbody>
      </table>
      <div v-else>
        <p>No data received</p>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  data() {
    return {
      form: {
        basePrice: '',
        vehicleType: 'option1'
      },
      submitted: false,
      apiResponse: null
    }
  },
  methods: {
    async handleSubmit() {
      try {
        const response = await axios.post(import.meta.env.VITE_APP_API_BASE_URL + '/Bid', this.form)
        this.apiResponse = response.data
        this.submitted = true
      } catch (error) {
        console.error('Error submitting form:', error)
        this.apiResponse = { error: 'Failed to submit form' }
        this.submitted = true
      }
    }
  }
}
</script>

<style scoped>
#app {
  font-family: 'Open Sans', sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  margin-top: 60px;
}

form {
  margin-bottom: 20px;
}

form div {
  margin-bottom: 10px;
}

label {
  margin-right: 10px;
}

button {
  padding: 5px 10px;
  background-color: blue;
  color: white;
  font-weight: 700;
}

pre {
  text-align: left;
  background-color: #f8f8f8;
  padding: 10px;
  border: 1px solid #ddd;
}
</style>
