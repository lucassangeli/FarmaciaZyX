using Farmacia.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.BLL
{
    public class FuncionarioBLL : BaseValidator<Funcionario>, EntityCrud<Funcionario>
    {
        public override bool Validate(Funcionario item)
        {
            bool b = true;
            if (string.IsNullOrWhiteSpace(item.CPF))
            {
                AddError("O CPF deve ser informado.");
                b = false;
            }
            else if (!CommonValidations.IsCPF(item.CPF))
            {
                AddError("O CPF não é válido.");
                b = false;
            }

            if (string.IsNullOrWhiteSpace(item.RG))
            {
                AddError("O RG deve ser informado.");
                b = false;
            }
            else if (!CommonValidations.IsRG(item.RG))
            {
                AddError("O RG não é válido.");
                b = false;
            }

            if (string.IsNullOrWhiteSpace(item.Nome))
            {
                AddError("O nome deve ser informado.");
                b = false;
            }
            else if (!CommonValidations.IsValidString(1, 60, item.Nome))
            {
                AddError("O nome deve ter entre 1 e 60 caracteres.");
                b = false;
            }

            if (string.IsNullOrWhiteSpace(item.Telefone))
            {
                AddError("O telefone deve ser informado.");
                b = false;
            }
            else if (!CommonValidations.IsValidString(8, 15, item.Telefone))
            {
                AddError("O telefone deve conter entre 8 e 15 caracteres.");
                b = false;
            }

            if (string.IsNullOrWhiteSpace(item.Email))
            {
                AddError("O email deve ser informado.");
                b = false;
            }
            else if (!CommonValidations.IsValidString(10, 50, item.Email))
            {
                AddError("O email deve conter entre 10 e 50 caracteres.");
                b = false;
            }
            else if (!CommonValidations.IsEmail(item.Email))
            {
                AddError("O email está inválido.");
                b = false;
            }

            if (string.IsNullOrWhiteSpace(item.Endereco))
            {
                AddError("O endereço deve ser informado.");
                b = false;
            }
            else if (!CommonValidations.IsValidString(1, 50, item.Endereco))
            {
                AddError("O endereço deve conter entre 1 e 50 caracteres.");
                b = false;
            }

            if (string.IsNullOrWhiteSpace(item.Senha))
            {
                AddError("A senha deve ser informada.");
                b = false;
            }
            else if (!CommonValidations.IsValidString(1, 30, item.Senha))
            {
                AddError("A senha deve conter entre 1 e 30 caracteres.");
                b = false;
            }

            if (item.Administrador != true && item.Administrador != false)
            {
                AddError("O administrador pode ser apenas ativo (1) ou inativo (0).");
                b = false;
            }

            base.Validate(item);
            return b;
        }

        public bool Insert(Funcionario item)
        {
            if (Validate(item))
                return (new FuncionarioDao().Insert(item));
            return false;
        }

        public bool Update(Funcionario item)
        {
            if (Validate(item))
                return (new FuncionarioDao().Update(item));
            return false;
        }

        public bool Delete(Funcionario item)
        {
            return (new FuncionarioDao().Delete(item));
        }

        public Funcionario GetById(int id)
        {
            Funcionario funcionario = new FuncionarioDao().GetById(id);
            if (funcionario == null)
            {
                throw new Exception("Funcionário não encontrado!");
            }
            return funcionario;
        }

        public List<Funcionario> GetAll()
        {
            return new FuncionarioDao().GetAll();
        }

        public Funcionario getByNome(string nome)
        {
            Funcionario funcionario = new FuncionarioDao().getByNome(nome);
            if (funcionario == null)
            {
                throw new Exception("Funcionário não encontrado!");
            }
            return funcionario;
        }

        public bool isNull(Funcionario registro)
        {
            Funcionario fun = new FuncionarioDao().GetUsuarioPorLoginSenha(registro);
            if (fun != null)
            {
                Utility.StaticUser.Administrador = fun.Administrador;
                Utility.StaticUser.Email = fun.Email;
                Utility.StaticUser.Senha = fun.Senha;
                return true;
            }
            return false;

        }
    }
}
