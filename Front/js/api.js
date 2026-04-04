export class EcoStepApi {
    constructor(baseUrl = 'http://localhost:5000/api') {
        this.baseUrl = baseUrl;
        this.token = localStorage.getItem('jwt_token');
    }
  
    async request(endpoint, method = 'GET', body = null, isAuth = false) {
        const headers = {}

        if (!isAuth) {
            headers['Content-Type'] = 'application/json';
        }

        if (this.token) {
            headers['Authorization'] = `Bearer ${this.token}`;
        }
        const options = {
            cahe: 'no-cache',
            method,
            headers
        }

        if (body) {
            options['body'] = isAuth ? body : JSON.stringify(body)
        }

        const response = await fetch(`${this.baseUrl}${endpoint}`, options);
    
        if (!response.ok) {
            const error = await response.text();
            throw new Error(error.message || 'Request failed');
        }
        return response.json();
    }

    async register(username, password) {
        const formData = new FormData();
        formData.append('username', username);
        formData.append('password', password);
        return this.request('/auth/register', 'POST', formData, true);
    }
  
    async login(username, password) {
        const formData = new FormData();
        formData.append('username', username);
        formData.append('password', password);

        const data = await this.request('/auth/login', 'POST', formData, true);
        this.token = data.token;
        this.userId = data.userId;
        console.log(this.token);
        localStorage.setItem('jwt_token', this.token);
        localStorage.setItem('userId', this.userId);
        return data;
    }

    async getSurveys(userId) {
        return this.request(`/survey/${userId}`);
    }

    async getLastWeekSurveys(userId) {
        return this.request(`/survey/${userId}/last-week-surveys`)
    }
  
    async createSurvey(surveyData) {
        return this.request('/survey', 'POST', surveyData);
    }

    async getUser(id) {
        return this.request(`/user/${id}`);
    }
  
    async updateHousehold(userId, householdData) {
        return this.request(`/user/${userId}/household`, 'PUT', householdData);
    }
  }