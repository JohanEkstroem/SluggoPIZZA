import { useState, useEffect } from 'react';
import PizzaList from './PizzaList';

export default function Pizza() {
  const [data, setData] = useState([]);
  const [error, setError] = useState(null);
  const API_URL = 'http://localhost:5000/api/pizzas';
  const headers = {
    'Content-Type': 'application/json',
  };
  useEffect(() => {
    // TODO: fetch data from API
    fetchPizzaData();
  }, []);

  const fetchPizzaData = () => {
    fetch(API_URL)
      .then((response) => response.json())
      .then((data) => setData(data))
      .catch((error) => setError(error));
  };
  const handleCreate = (item) => {
    // TODO: create item on API
  };

  const handleUpdate = (item) => {
    // TODO: update item on API
  };

  const handleDelete = (id) => {
    // TODO: delete item on API
  };

  return (
    <div>
      <PizzaList data={data} />
    </div>
  );
}
