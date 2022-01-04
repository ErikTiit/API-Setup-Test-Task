import fetch from 'node-fetch';

const { API_URL } = process.env;

describe('Car endpoint', () => {
  it('Should be able to create a car', async () => {
    const response = await fetch(`${API_URL}/car`, {
      headers: {
        'content-type': 'application/json',
      },
      method: 'POST',
      body: JSON.stringify({
        vinNumber: '5FNRL18613B046732',
        make: 'Honda',
        model: 'Odyssey',
        year: 2003,
        registrationCode: '111AAA',
      }),
    });

    expect(response.ok).toBe(true);
    expect(response.status).toBe(200);
  });

  it('Should be able to update car parameters', async () => {
    const response = await fetch(`${API_URL}/car/5FNRL18613B046732`, {
      headers: {
        'content-type': 'application/json',
      },
      method: 'PATCH',
      body: JSON.stringify({
        registrationCode: '222BBB',
      }),
    });

    expect(response.ok).toBe(true);
    expect(response.status).toBe(200);
  });

  it('Should be able to fetch cars', async () => {
    const response = await fetch(`${API_URL}/car`);

    expect(response.ok).toBe(true);
    expect(response.status).toBe(200);
    const cars = await response.json();
    expect(cars.length).toBe(1);
  });

  it('Should be able to fetch a spesific', async () => {
    const response = await fetch(`${API_URL}/car/5FNRL18613B046732`);

    expect(response.ok).toBe(true);
    expect(response.status).toBe(200);
    const car = await response.json();
    expect(car.make).toBe('Honda');
    expect(car.model).toBe('Odyssey');
    expect(car.year).toBe('2003');
    expect(car.registrationCode).toBe('222BBB');
  });

  it('Should be able to delete a car', async () => {
    const deleteResponse = await fetch(`${API_URL}/car/5FNRL18613B046732`, {
      method: 'DELETE',
    });
    expect(deleteResponse.ok).toBe(true);
    expect(deleteResponse.status).toBe(200);

    const getResponse = await fetch(`${API_URL}/car`);
    const cars = await getResponse.json();
    expect(cars.length).toBe(0);
  });
});
