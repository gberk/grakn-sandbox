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
        const [readSession, session, client] = this.openReadSession();
        let answerIterator = await readSession.query(query);
        this.closeReadSession(readSession, session, client);
        return answerIterator.collect();
    }
    private closeReadSession(readSession, session, client) {
        readSession.close();
        session.close();
        client.close();
    }

    private openReadSession() {
        const client = new GraknClient(this._location);
        const session = client.session(this._keyspace);
        const readSession = session.transaction().read();
        return [readSession, session, client];
    }
}

export default GraknRepository;