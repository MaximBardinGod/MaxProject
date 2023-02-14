import React, { Component } from 'react';

export class Result extends Component {
    static displayName = Result.name;

    render() {
        return (
            <div>
                <h1>Лучшая фитнесс среда для вас!</h1>
                <h3>Наши преимущества</h3>
                <ol className="rounded">
                    <li><a href="#">Первоклассные специалисты</a></li>
                    <li><a href="#">Низкая цена</a></li>
                    <li><a href="#">Быстрый результат</a></li>
                </ol>
            </div>
        );
    }
}