import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <h1 className="h1-full">Лучшая фитнесс среда для вас</h1>
        <h3 className="h3-home">Наши преимущества</h3>
          <ol className="rounded">
              <li><a href="#">Первоклассные специалисты</a></li>
              <li><a href="#">Низкая цена</a></li>
              <li><a href="#">Быстрый результат</a></li>
          </ol>
      </div>
    );
  }
}
