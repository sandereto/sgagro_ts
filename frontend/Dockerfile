# FRONTEND

FROM node:lts

RUN curl -sS http://dl.yarnpkg.com/debian/pubkey.gpg | apt-key add -

RUN echo "deb http://dl.yarnpkg.com/debian/ stable main" | tee /etc/apt/sources.list.d/yarn.list

RUN apt-get update

RUN apt-get install -y yarn

WORKDIR /usr/frontend

COPY package*.json ./

COPY yarn.lock ./

RUN yarn

COPY . .

CMD ["yarn", "start"]
