using Model.Dal;
using Model.Entity;
using System;
using System.Collections.Generic;

namespace Model.Negocios
{
    public class ClienteNeg
    {

        private ClienteDao objClienteDao;

        public ClienteNeg()
        {
            objClienteDao = new ClienteDao();

        }

        public void create(Cliente objCliente)
        {
            bool verificacao = true;

            string nome = objCliente.NomeCliente;
            if (nome == null)
            {
                objCliente.Estado = 20;
                return;
            }
            else
            {
                nome = objCliente.NomeCliente.Trim();
                verificacao = nome.Length <= 30 && nome.Length > 0;
                if (!verificacao)
                {
                    objCliente.Estado = 2;
                    return;
                }

            }
            //end validar nome




            //begin validar endereco retorna estado=6
            string endereco = objCliente.Endereco;
            if (endereco == null)
            {
                objCliente.Estado = 60;
                return;
            }
            else
            {
                endereco = objCliente.Endereco.Trim();
                verificacao = endereco.Length <= 50 && endereco.Length > 0;
                if (!verificacao)
                {
                    objCliente.Estado = 6;
                    return;
                }

            }
            //end validar endereco



            //begin verificar duplicidade retorna estado=8
            Cliente objClienteAux = new Cliente();
            objClienteAux.idCliente = objCliente.idCliente;

            verificacao = !objClienteDao.find(objClienteAux);
            if (!verificacao)
            {
                objCliente.Estado = 8;
                return;
            }
            //end validar duplicidade



            //se nao tem erro
            objCliente.Estado = 99;
            objClienteDao.create(objCliente);
            return;
        }

        public void update(Cliente objCliente)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string codigo = objCliente.idCliente.ToString();

            long id = 0;

            if (codigo == null)
            {
                objCliente.Estado = 10;
                return;
            }
            else
            {
                try
                {
                    id = Convert.ToInt64(objCliente.idCliente);
                    verificacao = codigo.Length > 0 && codigo.Length < 999999; ;


                    if (!verificacao)
                    {
                        objCliente.Estado = 1;
                        return;
                    }
                }
                catch (Exception e)
                {
                    objCliente.Estado = 100;
                    return;
                }

            }
            //end validar codigo


            //begin validar nome retorna estado=2
            string nome = objCliente.NomeCliente;
            if (nome == null)
            {
                objCliente.Estado = 20;
                return;
            }
            else
            {
                nome = objCliente.NomeCliente.Trim();
                verificacao = nome.Length <= 30 && nome.Length > 0;
                if (!verificacao)
                {
                    objCliente.Estado = 2;
                    return;
                }

            }
            //end validar nome




            //begin validar endereço retorna estado=6
            string endereco = objCliente.Endereco;
            if (endereco == null)
            {
                objCliente.Estado = 60;
                return;
            }
            else
            {
                endereco = objCliente.Endereco.Trim();
                verificacao = endereco.Length <= 50 && endereco.Length > 0;
                if (!verificacao)
                {
                    objCliente.Estado = 6;
                    return;
                }

            }
            //end validar endereco



            //se nao tem erro
            objCliente.Estado = 99;
            objClienteDao.update(objCliente);
            return;
        }

        public void delete(Cliente objCliente)
        {
            bool verificacao = true;
            //verificando se existe
            Cliente objClienteAux = new Cliente();

            objClienteAux.idCliente = objCliente.idCliente;

            verificacao = objClienteDao.find(objClienteAux);
            if (!verificacao)
            {
                objCliente.Estado = 33;
                return;
            }


            objCliente.Estado = 99;
            objClienteDao.delete(objCliente);
            return;
        }

        public bool find(Cliente objCliente)
        {
            return objClienteDao.find(objCliente);
        }

        public List<Cliente> findAll()
        {
            return objClienteDao.findAll();
        }

        public List<Cliente> findAllClientes(Cliente objCLiente)
        {
            return objClienteDao.findAllCliente(objCLiente);
        }

    }
}
