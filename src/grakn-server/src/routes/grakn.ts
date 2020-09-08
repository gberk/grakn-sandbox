import { Request, Response, Router } from 'express';
import { BAD_REQUEST, CREATED, OK } from 'http-status-codes';
import { ParamsDictionary } from 'express-serve-static-core';

import { paramMissingError } from '@shared/constants';
import {GeneralWebhookFulfillmentRequest, GeneralFulfillmentResponse} from '@voicify/voicify-sdk-webhooks'

import GraknRepo from '../repos/grakn';
// Init shared
const router = Router();
const repo = new GraknRepo("localhost:48555","bagel_bar");

router.get('/query/voicify', async (req: Request, res: Response) => {
    var voicifyRequest = req.body as GeneralWebhookFulfillmentRequest;
    var queryToExecute = voicifyRequest.parameters?.["query"];

    if(!queryToExecute)
        return res.status(BAD_REQUEST).json({
            error: "query not defined"
        });

    var result = await repo.query(queryToExecute);
    console.log(result);

    var voicifyResponse = {
        data: {
            content: "Query executed"
        }
    } as GeneralFulfillmentResponse;
    
    res.send().json(voicifyResponse);
});

router.get('/query/raw', async (req: Request, res: Response) => {
    var queryToExecute = req.query.query as string;

    if(!queryToExecute)
        return res.status(BAD_REQUEST).json({
            error: "query not defined"
        });

    var result = await repo.query(queryToExecute);
    console.log(result);

    res.send().json({
        data: result
    });
});


export default router;