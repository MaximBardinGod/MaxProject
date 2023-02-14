import React, { Component } from 'react';

export class Mentors extends Component {
    static displayName = Mentors.name;

    render() {
        return (
            <div>
                <h1 className="h1-full">Тренеры</h1>
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