FROM node:lts-alpine as build

WORKDIR /app

COPY package*.json .
COPY yarn.lock .

RUN yarn install

COPY . ./

ENV REACT_APP_API_URL=http://localhost:5000

RUN yarn run build

FROM nginx:stable-alpine

COPY --from=build /app/build /usr/share/nginx/html
COPY nginx/nginx.conf /etc/nginx/conf.d/default.conf

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
