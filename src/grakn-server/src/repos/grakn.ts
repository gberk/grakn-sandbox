const GraknClient = require("grakn-client");

class GraknRepository {
    _location: string;
    _keyspace: string;

    constructor(location: string, keyspace:string){
        this._keyspace = keyspace;
        this._location = location;
    }

    async query(query:string) : Promise<any>
    {
        const [readTransaction, session, client] = await this.openReadSession();
        let answerIterator = await readTransaction.query(query);
        await this.closeReadSession(readTransaction, session, client);
        var collectedResult = await answerIterator.collect();
        return collectedResult;
    }
    private async closeReadSession(readSession, session, client) {
        await readSession.close();
        await session.close();
        await client.close();
    }

    private async openReadSession() {
        const client = new GraknClient(this._location);
        const session = await client.session(this._keyspace);
        const readTransaction = await session.transaction().read();
        return [readTransaction, session, client];
    }
}

export default GraknRepository;