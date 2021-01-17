interface Config {
    apiUrl: string;
}

const config: Config = {
    apiUrl: process.env.REACT_APP_API_URL || "http://localhost:5000"
}

export default config;