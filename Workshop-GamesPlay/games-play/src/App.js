import { Routes, Route, useNavigate } from 'react-router-dom';
import { useEffect, useState } from "react";

import * as gameService from './services/gameService'
import { AuthContext } from './contexts/AuthContext';
import { GameContext } from './contexts/GameContext';

import Header from './components/Header/Header';
import Home from './components/Home'
import Login from './components/Login/Login';
import Logout from './components/Logout/Logout';
import Register from './components/Register/Register';
import Create from './components/Create/Create';
import EditGame from './components/EditGame/EditGame';
import Catalog from './components/Catalog/Catalog';
import Details from './components/Details/Details';
import './App.css';
import { useLocalStorage } from './components/Hooks/useLocalStorage';

function App() {
    const [games, setGames] = useState([]);
    const [auth, setAuth] = useLocalStorage('auth', {});
    const navigate = useNavigate();

    const addComment = (gameId, comment) => {
        setGames(state => {
            const game = state.find(x => x._id === gameId);
            const comments = game.comments || [];
            comments.push(comment);

            return [
                ...state.filter(x => x._id !== gameId),
                { ...game, comments }
            ]
        })
    }

    const gameAdd = (gameData) => {
        setGames(state => [
            ...state,
            gameData
        ])
        navigate('/catalog');
    }

    const userLogin = (authData) => {
        setAuth(authData);
    }

    const userLogout = () => {
        setAuth({});
    }

    const gameEdit = (gameId, gameData) => {
        setGames(state => state.map(x => x._id === gameId ? gameData : x));
    }

    useEffect(() => {
        gameService.getAll()
            .then(result => {
                setGames(result);
            })
    }, []);


    return (
        <AuthContext.Provider value={{ user: auth, userLogin, userLogout }}>
            <div id="box">
                <Header />

                <GameContext.Provider value={{ games, gameAdd, gameEdit }}>
                    <main id="main-content">
                        <Routes>
                            <Route path="/" element={<Home games={games} />} />
                            <Route path="/login" element={<Login />} />
                            <Route path="/logout" element={<Logout />} />
                            <Route path="/register" element={<Register />} />
                            <Route path="/create" element={<Create />} />
                            <Route path="/games/:gameId/edit" element={<EditGame />} />
                            <Route path="/catalog" element={<Catalog games={games} />} />
                            <Route path="/catalog/:gameId" element={<Details games={games} addComment={addComment} />} />
                        </Routes>
                    </main>
                </GameContext.Provider>
            </div>
        </AuthContext.Provider>
    );
};

export default App;
