FROM node:12 as node

WORKDIR /app

COPY package*.json ./

RUN npm install -g @angular/cli @angular-devkit/build-angular && npm install

COPY . .

EXPOSE 4201
CMD [ "npm", "run", "start" ]