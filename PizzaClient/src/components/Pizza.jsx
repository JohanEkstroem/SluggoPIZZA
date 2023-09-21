import { useState, useEffect } from 'react';
import PizzaList from './PizzaList';
const API_URL = 'http://localhost:5000/api/pizzas';
const headers = {
  'Content-Type': 'application/json',
};
const term = 'Pizza';

export default function Pizza() {
  const [data, setData] = useState([]);
  const [error, setError] = useState(null);

  useEffect(() => {
    fetchPizzaData();
  }, []);

  const fetchPizzaData = () => {
    fetch(API_URL)
      .then((response) => response.json())
      .then((data) => setData(data))
      .catch((error) => setError(error));
  };
  const handleCreate = (item) => {
    fetch(API_URL, {
      method: 'POST',
      headers,
      body: JSON.stringify({ name: item.name, description: item.description }),
    })
      .then((response) => response.json())
      .then((returnedItem) => setData([...data, returnedItem]))
      .catch((error) => setError(error));
  };

  const handleUpdate = (updatedItem) => {
    fetch(`${API_URL}/${updatedItem.id}`, {
      method: 'PUT',
      headers,
      body: JSON.stringify(updatedItem),
    })
      .then(() =>
        setData(
          data.map((item) => (item.id === updatedItem.id ? updatedItem : item))
        )
      )
      .catch((error) => setError(error));
  };

  const handleDelete = (id) => {
    fetch(`${API_URL}/${id}`, {
      method: 'DELETE',
      headers,
    })
      .then(() => setData(data.filter((item) => item.id !== id)))
      .catch((error) => console.error('Error deleting item:', error));
  };

  return (
    <div>
      <PizzaList
        name={term}
        data={data}
        error={error}
        onCreate={handleCreate}
        onUpdate={handleUpdate}
        onDelete={handleDelete}
      />
    </div>
  );
}
