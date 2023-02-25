import fetch from 'node-fetch';

const { API_URL } = process.env;

describe('Car endpoint', () => {
  it('Should be able to create a car', async () => {
    const response = await fetch(`https://localhost:7089/vehicles`, {
      headers: {
        'content-type': 'application/json',
      },
      method: 'POST',
      body: JSON.stringify({
        vin: '5FNRL18613B046732',
        make: 'Honda',
        model: 'Odyssey',
        year: 2003,
        registrationCode: '111AAA',
      }),
    });

    expect(response.ok).toBe(true);
    expect(response.status).toBe(201);
  });

  it('Should be able to add multiple cars', async () => {
    const responses = await Promise.all([
      fetch(`https://localhost:7089/vehicles`, {
        headers: {
          'content-type': 'application/json',
        },
        method: 'POST',
        body: JSON.stringify({
          vin: 'KLATA52671B611178',
          make: 'Daewoo',
          model: 'Lanos',
          year: 2001,
          registrationCode: '333CCC',
        }),
      }),
      fetch(`https://localhost:7089/vehicles`, {
        headers: {
          'content-type': 'application/json',
        },
        method: 'POST',
        body: JSON.stringify({
          vin: '2FMDK4KC7BBA48439',
          make: 'Ford',
          model: 'Edge',
          year: 2011,
          registrationCode: '444DDD',
        }),
      }),
    ]);

    expect(responses.map((response) => response.ok)).toEqual([true, true]);
    expect(responses.map((response) => response.status)).toEqual([201, 201]);
  });

  it('Should be able to update car parameters', async () => {
    const response = await fetch(`https://localhost:7089/vehicles/5FNRL18613B046732`, {
      headers: {
        'content-type': 'application/json-patch+json',
      },
      method: 'PATCH',
      body:  "[{\"op\":\"replace\",\"path\":\"/registrationCode\",\"value\":\"222BBB\"}]",
    });

    expect(response.ok).toBe(true);
    expect(response.status).toBe(200);
  });

  it('Should be able to fetch cars', async () => {
    const response = await fetch(`https://localhost:7089/vehicles`);

    expect(response.ok).toBe(true);
    expect(response.status).toBe(200);
    const cars = await response.json();
    expect(cars.length).toBe(3);
  });

  it('Should be able to fetch a spesific', async () => {
    const response = await fetch(`https://localhost:7089/vehicles/5FNRL18613B046732`);

    expect(response.ok).toBe(true);
    expect(response.status).toBe(200);
    const car = await response.json();
    expect(car.make).toBe('Honda');
    expect(car.model).toBe('Odyssey');
    expect(car.year).toBe(2003);
    expect(car.registrationCode).toBe('222BBB');
  });

  it('Should be able to delete a car', async () => {
    const deleteResponse = await fetch(`https://localhost:7089/vehicles/5FNRL18613B046732`, {
      method: 'DELETE',
    });
    expect(deleteResponse.ok).toBe(true);
    expect(deleteResponse.status).toBe(200);

    const getResponse = await fetch(`https://localhost:7089/vehicles`);
    const cars = await getResponse.json();
    expect(cars.length).toBe(2);
  });
  it('removes the remaining cars', async () => {
    const deleteResponse = await fetch(`https://localhost:7089/vehicles/2FMDK4KC7BBA48439`, {
      method: 'DELETE',
      
    });
    const deleteResponse2 = await fetch(`https://localhost:7089/vehicles/KLATA52671B611178`, {
      method: 'DELETE',
    
    });
  });
});

